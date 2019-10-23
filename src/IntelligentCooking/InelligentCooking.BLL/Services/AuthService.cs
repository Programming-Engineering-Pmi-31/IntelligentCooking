using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using InelligentCooking.BLL.Infrastructure.Exceptions;
using InelligentCooking.BLL.Interfaces;
using InelligentCooking.BLL.Models.ResponseModels;
using InelligentCooking.BLL.Settings;
using IntelligentCooking.Core.Entities;
using IntelligentCooking.Core.Interfaces.UnitsOfWork;
using IntelligentCooking.Web.Models.RequestModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace InelligentCooking.BLL.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly TokenValidationParameters _tokenValidationParameters;
        private readonly IIntelligentCookingUnitOfWork _unitOfWork;
        private readonly JwtSettings _jwtSettings;

        public AuthService(
            UserManager<User> userManager,
            IOptions<JwtSettings> jwtOptions,
            TokenValidationParameters tokenValidationParameters,
            IIntelligentCookingUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _tokenValidationParameters = tokenValidationParameters;
            _unitOfWork = unitOfWork;
            _jwtSettings = jwtOptions.Value;
        }

        public async Task<AuthResponse> RegisterAsync(UserRegistrationRequest registrationRequest)
        {
            var newUser = new User
            {
                Email = registrationRequest.Email,
                UserName = registrationRequest.UserName
            };

            var createdUser = await _userManager.CreateAsync(newUser, registrationRequest.Password);

            if(!createdUser.Succeeded)
            {
                ExceptionHandler.RegistrationException(createdUser.Errors);
            }

            return await GenerateUserToken(newUser);
        }

        public async Task<AuthResponse> LoginAsync(UserLoginRequest loginRequest)
        {
            var user = await _userManager.FindByEmailAsync(loginRequest.Email);

            if(user == null)
            {
                ExceptionHandler.NotFound(nameof(User));
            }

            var userHasValidPassword = await _userManager.CheckPasswordAsync(user, loginRequest.Password);

            if(!userHasValidPassword)
            {
                ExceptionHandler.InvalidPasswordException();
            }

            return await GenerateUserToken(user);
        }

        public async Task<AuthResponse> RefreshTokenAsync(RefreshTokenRequest refreshTokenRequest)
        {
            var validatedToken = GetPrincipalFromToken(refreshTokenRequest.Token);

            var expiryDateUnix = long.Parse(
                validatedToken.Claims.Single(x => x.Type == JwtRegisteredClaimNames.Exp)
                    .Value);

            var expiryDateUtc = new DateTime(
                TimeSpan.FromSeconds(expiryDateUnix)
                    .Ticks,
                DateTimeKind.Utc);

            if(expiryDateUtc > DateTime.UtcNow)
            {
                ExceptionHandler.TokenNotExpired();
            }

            var jti = validatedToken.Claims.Single(x => x.Type == JwtRegisteredClaimNames.Jti)
                .Value;

            var storedRefreshToken = await _unitOfWork.RefreshTokens.FindAsync(refreshTokenRequest.RefreshToken);

            if(storedRefreshToken == null || DateTime.UtcNow > storedRefreshToken.ExpirationDate || storedRefreshToken.IsInvalidated || storedRefreshToken.IsUsed || storedRefreshToken.JwtId != jti)
            {
                ExceptionHandler.InvalidTokenException();
            }

            storedRefreshToken.IsUsed = true;
            await _unitOfWork.CommitAsync();

            var user = await _userManager.FindByIdAsync(
                validatedToken.Claims.Single(x => x.Type == "id")
                    .Value);

            var tokenResult = await GenerateUserToken(user);

            return tokenResult;
        }

        private ClaimsPrincipal GetPrincipalFromToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var principal = tokenHandler.ValidateToken(token, _tokenValidationParameters, out var securityToken);

            if(!IsJwtWithValidSecurityAlgorithm(securityToken))
            {
                ExceptionHandler.InvalidTokenException();
            }

            return principal;
        }

        private bool IsJwtWithValidSecurityAlgorithm(SecurityToken validatedToken) =>
            validatedToken is JwtSecurityToken jwtSecurityToken
            && jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase);

        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }

        private async Task<AuthResponse> GenerateUserToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_jwtSettings.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                        new Claim(JwtRegisteredClaimNames.Jti, $"{Guid.NewGuid()}"),
                        new Claim(JwtRegisteredClaimNames.Email, user.Email),
                        new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
                        new Claim("id", $"{user.Id}")
                    }),
                Expires = DateTime.UtcNow.Add(_jwtSettings.LifeTime),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            var refreshToken = new RefreshToken
            {
                Token = GenerateRefreshToken(),
                JwtId = token.Id,
                UserId = user.Id,
                CreationDate = DateTime.UtcNow,
                ExpirationDate = DateTime.UtcNow.AddMonths(6), //GET FROM CONFIGURATION

            };

            _unitOfWork.RefreshTokens.Add(refreshToken);
            await _unitOfWork.CommitAsync();

            return new AuthResponse
            {
                Token = tokenHandler.WriteToken(token),
                RefreshToken = refreshToken.Token
            };
        }
    }
}
