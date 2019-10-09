using IntelligentCooking.Core.Interfaces.Repositories;
using IntelligentCooking.DAL.Context;
using Microsoft.AspNetCore.Identity;

namespace IntelligentCooking.DAL.Repositories
{
    public class UserTokenRepository: Repository<IdentityUserToken<int>>, IUserTokenRepository
    {
        public UserTokenRepository(IntelligentCookingContext context) : base(context) {}
    }
}
