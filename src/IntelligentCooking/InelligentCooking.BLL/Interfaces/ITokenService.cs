using System.Security.Claims;
using IntelligentCooking.Core.Entities;

namespace InelligentCooking.BLL.Interfaces
{
    public interface ITokenService
    {
        RefreshToken GenerateRefreshToken(string jwtToken);
        string GenerateJwtToken(User user);
        ClaimsPrincipal GetPrincipalFromToken(string token);
    }
}
