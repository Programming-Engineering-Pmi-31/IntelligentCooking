using IntelligentCooking.Core.Entities;
using IntelligentCooking.Core.Interfaces.Repositories;
using IntelligentCooking.DAL.Context;

namespace IntelligentCooking.DAL.Repositories
{
    public class RefreshTokenRespository: Repository<RefreshToken, string>, IRefreshTokenRepository
    {
        public RefreshTokenRespository(IntelligentCookingContext context) : base(context) {}
    }
}
