using IntelligentCooking.Core.Interfaces.Repositories;
using IntelligentCooking.DAL.Context;
using Microsoft.AspNetCore.Identity;

namespace IntelligentCooking.DAL.Repositories
{
    public class UserRoleRepository: Repository<IdentityUserRole<int>>, IUserRoleRepository
    {
        public UserRoleRepository(IntelligentCookingContext context) : base(context) {}
    }
}
