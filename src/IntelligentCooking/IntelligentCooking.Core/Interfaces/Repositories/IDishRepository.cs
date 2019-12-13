using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using IntelligentCooking.Core.Entities;

namespace IntelligentCooking.Core.Interfaces.Repositories
{
    public interface IDishRepository: IRepository<Dish, int>
    {
        Task<IEnumerable<Dish>> GetDishesWithIngredientsCategoriesAndRatingsAsync(int? skip, int? take);
        Task<IEnumerable<Dish>> GetSortedDishesAsync<T>(Expression<Func<Dish, T>> filter, bool ascending, int? skip, int? take);
        Task<Dish> GetByNameAsync(string name);
        Task<IEnumerable<Dish>> GetByIngredientsAsync(IEnumerable<int> ingredientIds);
        Task<IEnumerable<Dish>> GetTop(int amount);
    }
}
