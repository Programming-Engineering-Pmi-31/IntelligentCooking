using System.Collections.Generic;
using System.Threading.Tasks;
using IntelligentCooking.Core.Entities;

namespace IntelligentCooking.Core.Interfaces.Repositories
{
    public interface IDishRepository
    {
        Dish Add(Dish dish);
        Task<IEnumerable<Dish>> GetDishesWithIngredientsCategoriesAndLikes(int? skip, int? take, bool byTime, bool byCalories);
        Task<Dish> FindAsync(int id);
    }
}
