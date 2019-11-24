using System.Security.Claims;
using System.Threading.Tasks;
using IntelligentCooking.Core.Entities;

namespace InelligentCooking.BLL.Interfaces
{
    public interface ITokenService
    {
        RefreshToken GenerateRefreshToken(string jwtToken);

        Task<string> GenerateJwtToken(User user);

        ClaimsPrincipal GetPrincipalFromToken(string token);
    }
}
