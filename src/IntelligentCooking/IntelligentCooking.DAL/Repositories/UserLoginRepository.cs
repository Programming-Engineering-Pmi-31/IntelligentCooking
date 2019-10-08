using IntelligentCooking.Core.Interfaces.Repositories;
using IntelligentCooking.DAL.Context;
using Microsoft.AspNetCore.Identity;

namespace IntelligentCooking.DAL.Repositories
{
    public class UserLoginRepository: Repository<IdentityUserLogin<int>>, IUserLoginRepository
    {
        public UserLoginRepository(IntelligentCookingContext context) : base(context) {}
    }
}
