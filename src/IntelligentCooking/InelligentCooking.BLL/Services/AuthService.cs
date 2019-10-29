using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
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
        private readonly ITokenService _tokenService;
        private readonly JwtSettings _jwtSettings;

        public AuthService(
            UserManager<User> userManager,
            IOptions<JwtSettings> jwtOptions,
            TokenValidationParameters tokenValidationParameters,
            IIntelligentCookingUnitOfWork unitOfWork,
            ITokenService tokenService)
        {
            _userManager = userManager;
            _tokenValidationParameters = tokenValidationParameters;
            _unitOfWork = unitOfWork;
            _tokenService = tokenService;
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
            var validatedToken = _tokenService.GetPrincipalFromToken(refreshTokenRequest.Token);

            var expiryDateUtc = UnixTimeStampToDateTime(
                validatedToken.Claims.Single(x => x.Type == JwtRegisteredClaimNames.Exp)
                    .Value);

            if (expiryDateUtc > DateTime.UtcNow)
            {
                ExceptionHandler.TokenNotExpired();
            }

            var jti = validatedToken.Claims.Single(x => x.Type == JwtRegisteredClaimNames.Jti)
                .Value;

            var storedRefreshToken = await _unitOfWork.RefreshTokens.FindAsync(refreshTokenRequest.RefreshToken);

            if(storedRefreshToken == null
               || DateTime.UtcNow > storedRefreshToken.ExpirationDate
               || storedRefreshToken.IsInvalidated
               || storedRefreshToken.IsUsed
               || storedRefreshToken.JwtId != jti)
            {
                ExceptionHandler.InvalidTokenException();
            }

            storedRefreshToken.IsUsed = true;

            var user = await _userManager.FindByIdAsync(
                validatedToken.Claims.Single(x => x.Type == "id")
                    .Value);

            await _unitOfWork.CommitAsync();

            return await GenerateUserToken(user);
        }

        private async Task<AuthResponse> GenerateUserToken(User user)
        {
            var jwtToken = _tokenService.GenerateJwtToken(user);
            var refreshToken = _tokenService.GenerateRefreshToken(jwtToken);

            _unitOfWork.RefreshTokens.Add(refreshToken);
            await _unitOfWork.CommitAsync();

            return new AuthResponse
            {
                Token = jwtToken,
                RefreshToken = refreshToken.Token
            };
        }

        private static DateTime UnixTimeStampToDateTime(string unixTimeStamp)
        {
            var dtDateTime = new DateTime(
                1970,
                1,
                1,
                0,
                0,
                0,
                0,
                DateTimeKind.Utc);

            dtDateTime = dtDateTime.AddSeconds(long.Parse(unixTimeStamp))
                .ToUniversalTime();

            return dtDateTime;
        }
    }
}
