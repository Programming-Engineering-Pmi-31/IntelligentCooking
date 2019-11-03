using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using IntelligentCooking.Core.Entities;

namespace IntelligentCooking.Core.Interfaces.Repositories
{
    public interface IDishRepository: IRepository<Dish, int>
    {
        Task<IEnumerable<Dish>> GetDishesWithIngredientsCategoriesAndLikesAsync(int? skip, int? take);
        Task<Dish> GetByNameAsync(string name);
        Task<IEnumerable<Dish>> SortDishes<T>(Expression<Func<Dish, T>> filter, bool ascending, int? skip, int? take);
    }
}
