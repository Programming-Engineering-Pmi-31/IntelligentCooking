using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using InelligentCooking.BLL.Infrastructure.Exceptions;
using InelligentCooking.BLL.Interfaces;
using InelligentCooking.BLL.Settings;
using IntelligentCooking.Core.Entities;
using IntelligentCooking.Core.Interfaces.UnitsOfWork;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace InelligentCooking.BLL.Services
{
    public class TokenService: ITokenService
    {
        private readonly IIntelligentCookingUnitOfWork _unitOfWork;
        private readonly TokenValidationParameters _tokenValidationParameters;
        private readonly JwtSettings _jwtSettings;

        public TokenService(
            IIntelligentCookingUnitOfWork unitOfWork,
            IOptions<JwtSettings> jwtOptions,
            TokenValidationParameters tokenValidationParameters)
        {
            _unitOfWork = unitOfWork;
            _tokenValidationParameters = tokenValidationParameters;
            _jwtSettings = jwtOptions.Value;
        }

       
        public string GenerateJwtToken(User user)
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
                Expires = DateTime.UtcNow.Add(_jwtSettings.JwtTokenLifetime),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        public RefreshToken GenerateRefreshToken(string jwtToken)
        {
            var principal = GetPrincipalFromToken(jwtToken);

            var refreshToken = new RefreshToken
            {
                Token = GenerateRefreshToken(),
                JwtId = principal.Claims.Single(x => x.Type == JwtRegisteredClaimNames.Jti)
                    .Value,
                UserId = int.Parse(
                    principal.Claims.Single(x => x.Type == "id")
                        .Value),
                CreationDate = DateTime.UtcNow,
                ExpirationDate = DateTime.UtcNow.Add(_jwtSettings.RefreshTokenLifetime)
            };

            return refreshToken;
        }

        private bool IsJwtWithValidSecurityAlgorithm(SecurityToken validatedToken) =>
            validatedToken is JwtSecurityToken jwtSecurityToken
            && jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase);

        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];

            using(var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }

        public ClaimsPrincipal GetPrincipalFromToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var notValidateLifetimeToken = _tokenValidationParameters.Clone();
            notValidateLifetimeToken.ValidateLifetime = false;

            var principal = tokenHandler.ValidateToken(token, notValidateLifetimeToken, out var securityToken);

            if(!IsJwtWithValidSecurityAlgorithm(securityToken))
            {
                ExceptionHandler.InvalidTokenException();
            }

            return principal;
        }
    }
}
