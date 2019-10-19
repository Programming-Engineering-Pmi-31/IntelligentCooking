using IntelligentCooking.Core.Entities;

namespace IntelligentCooking.Core.Interfaces.Repositories
{
    public interface ILikeRepository: IRepository<Like, (int UserId, int DishId)>
    {
    }
}
