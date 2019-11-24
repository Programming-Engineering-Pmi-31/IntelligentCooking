using System.Collections.Generic;
using System.Threading.Tasks;
using IntelligentCooking.Core.Entities;

namespace IntelligentCooking.Core.Interfaces.Repositories
{
    public interface IRefreshTokenRepository : IRepository<RefreshToken, string>
    {
        Task<IEnumerable<RefreshToken>> GetExpiredTokensAsync();
    }
}
