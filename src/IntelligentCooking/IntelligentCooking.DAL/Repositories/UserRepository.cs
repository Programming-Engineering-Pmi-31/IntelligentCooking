using IntelligentCooking.Core.Entities;
using IntelligentCooking.Core.Interfaces.Repositories;
using IntelligentCooking.DAL.Context;

namespace IntelligentCooking.DAL.Repositories
{
    public class UserRepository: Repository<User, int>, IUserRepository
    {
        public UserRepository(IntelligentCookingContext context) : base(context) {}
    }
}
