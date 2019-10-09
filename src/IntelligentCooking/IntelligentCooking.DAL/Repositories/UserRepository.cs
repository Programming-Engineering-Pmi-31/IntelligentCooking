using IntelligentCooking.Core.Interfaces.Repositories;
using IntelligentCooking.DAL.Context;
using Microsoft.AspNetCore.Identity;

namespace IntelligentCooking.DAL.Repositories
{
    public class UserRepository: Repository<IdentityUser<int>>, IUserRepository
    {
        public UserRepository(IntelligentCookingContext context) : base(context) {}
    }
}
