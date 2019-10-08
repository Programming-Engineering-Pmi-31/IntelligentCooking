using IntelligentCooking.Core.Interfaces.Repositories;
using IntelligentCooking.DAL.Context;
using Microsoft.AspNetCore.Identity;

namespace IntelligentCooking.DAL.Repositories
{
    public class RoleClaimRepository: Repository<IdentityRoleClaim<int>>, IRoleClaimRepository
    {
        public RoleClaimRepository(IntelligentCookingContext context) : base(context) {}
    }
}
