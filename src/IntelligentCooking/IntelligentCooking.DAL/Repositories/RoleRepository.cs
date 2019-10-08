using IntelligentCooking.Core.Interfaces.Repositories;
using IntelligentCooking.DAL.Context;
using Microsoft.AspNetCore.Identity;

namespace IntelligentCooking.DAL.Repositories
{
    public class RoleRepository: Repository<IdentityUserRole<int>>, IRoleRepository
    {
        public RoleRepository(IntelligentCookingContext context) : base(context) {}
    }
}
