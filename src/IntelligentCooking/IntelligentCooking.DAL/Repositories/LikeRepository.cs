using IntelligentCooking.Core.Entities;
using IntelligentCooking.Core.Interfaces.Repositories;
using IntelligentCooking.DAL.Context;

namespace IntelligentCooking.DAL.Repositories
{
    public class LikeRepository: Repository<Like>, ILikeRepository
    {
        public LikeRepository(IntelligentCookingContext context) : base(context) {}
    }
}
