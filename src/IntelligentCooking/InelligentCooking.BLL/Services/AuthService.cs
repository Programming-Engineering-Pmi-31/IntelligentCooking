using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using InelligentCooking.BLL.Infrastructure.Exceptions;
using InelligentCooking.BLL.Interfaces;
using InelligentCooking.BLL.Models.ResponseModels;
using InelligentCooking.BLL.Settings;
using IntelligentCooking.Core.Entities;
using IntelligentCooking.Web.Models.RequestModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace InelligentCooking.BLL.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly IOptions<JwtSettings> _jwtOptions;

        public AuthService(UserManager<User> userManager, IOptions<JwtSettings> jwtOptions)
        {
            _userManager = userManager;
            _jwtOptions = jwtOptions;
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

            return GenerateUserToken(newUser);
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
                ExceptionHandler.LoginFailedException();
            }

            return GenerateUserToken(user);
        }

        private AuthResponse GenerateUserToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_jwtOptions.Value.Secret);

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
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new AuthResponse
            {
                Token = tokenHandler.WriteToken(token)
            };
        }
    }
}
