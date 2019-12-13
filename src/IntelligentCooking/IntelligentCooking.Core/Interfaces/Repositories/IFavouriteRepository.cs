using System.Collections.Generic;
using System.Threading.Tasks;
using IntelligentCooking.Core.Entities;

namespace IntelligentCooking.Core.Interfaces.Repositories
{
    public interface IFavouriteRepository: IRepository<Favourite, (int UserId, int DishId)>
    {
        Task<IEnumerable<Favourite>> GetWithDishesAsync(int userId);
    }
}
