using IntelligentCooking.Core.Interfaces.Repositories;
using IntelligentCooking.DAL.Context;
using Microsoft.AspNetCore.Identity;

namespace IntelligentCooking.DAL.Repositories
{
    public class UserClaimRepository: Repository<IdentityUserClaim<int>>, IUserClaimRepository
    {
        public UserClaimRepository(IntelligentCookingContext context) : base(context) {}
    }
}
