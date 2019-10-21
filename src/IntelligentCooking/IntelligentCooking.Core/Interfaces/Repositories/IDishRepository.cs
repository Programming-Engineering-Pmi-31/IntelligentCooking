using System.Collections.Generic;
using System.Threading.Tasks;
using IntelligentCooking.Core.Entities;

namespace IntelligentCooking.Core.Interfaces.Repositories
{
    public interface IDishRepository: IRepository<Dish, int>
    {
        Task<IEnumerable<Dish>> GetDishesWithIngredientsCategoriesAndLikesAsync(int? skip, int? take);
        Task<Dish> GetByNameAsync(string name);
    }
}
