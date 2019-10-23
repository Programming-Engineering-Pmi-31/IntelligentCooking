using System;
using System.Security.Claims;
using System.Threading.Tasks;
using IntelligentCooking.Core.Entities;
using IntelligentCooking.Web.Models.RequestModels;
using Microsoft.IdentityModel.Tokens;

namespace InelligentCooking.BLL.Interfaces
{
    public interface ITokenService
    {
        RefreshToken GenerateRefreshToken(string jwtToken);
        string GenerateJwtToken(User user);
        ClaimsPrincipal GetPrincipalFromToken(string token);
    }
}
