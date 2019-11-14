using System.Threading.Tasks;
using IntelligentCooking.Core.Entities;

namespace IntelligentCooking.Core.Interfaces.Repositories
{
    public interface ILikeRepository: IRepository<Like, (int UserId, int DishId)>
    {
        Task<double> AvgForDish(int dishId);
    }
}
