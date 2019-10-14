using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IntelligentCooking.Core.Entities;
using IntelligentCooking.Core.Interfaces.Repositories;
using IntelligentCooking.DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace IntelligentCooking.DAL.Repositories
{
    public class DishRepository : Repository<Dish>, IDishRepository
    {
        public DishRepository(IntelligentCookingContext context) : base(context) { }

        public async Task<IEnumerable<Dish>> GetDishesWithIngredientsCategoriesAndLikes(int? skip, int? take, bool byTime, bool byCalories)
        {
            var dishes = Context.Dishes.Include(d => d.DishIngredients)
                    .ThenInclude(di => di.Ingredient)
                    .Include(d => d.DishCategories)
                    .ThenInclude(d => d.Category);

            if (byTime)
            {
                dishes.OrderBy(d => d.Time);
            }
            else if (byCalories)
            {
                dishes.OrderBy(d => d.Calories);
            }

            if (skip != null && take != null)
            {
                dishes.Skip(skip.Value)
                    .Take(take.Value);
            }

            return await dishes.ToListAsync();
        }
    }
}
