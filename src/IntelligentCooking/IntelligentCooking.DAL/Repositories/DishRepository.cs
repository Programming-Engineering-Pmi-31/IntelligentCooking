using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IntelligentCooking.Core.Entities;
using IntelligentCooking.Core.Interfaces.Repositories;
using IntelligentCooking.DAL.Context;
using IntelligentCooking.DAL.Extensions;
using Microsoft.EntityFrameworkCore;

namespace IntelligentCooking.DAL.Repositories
{
    public class DishRepository : Repository<Dish>, IDishRepository
    {
        public DishRepository(IntelligentCookingContext context) : base(context) { }

        public async Task<IEnumerable<Dish>> GetDishesWithIngredientsCategoriesAndLikes(int? skip, int? take, bool byTime, bool byCalories)
        {
            var dishes = Context.Dishes.IncludeMainPageProps();

            if(skip.HasValue && take.HasValue)
            {
                dishes = dishes.Paginate(skip.Value, take.Value);
            }

            if (byTime)
            {
                dishes = dishes.OrderBy(d => d.Time);
            }

            if (byCalories)
            {
                dishes = dishes.OrderBy(d => d.Calories);
            }

            return await dishes.ToListAsync();
        }

        public async Task<Dish> FindAsync(int id)
        {
            return await Context.Dishes
                .IncludeMainPageProps()
                .Include(d => d.Likes)
                .FirstOrDefaultAsync(d => d.Id == id);
        }
    }

    static class DishQueriesExtentions
    {
        public static IQueryable<Dish> IncludeMainPageProps(this IQueryable<Dish> query)
        {
            return query.Include(d => d.DishIngredients)
                .ThenInclude(di => di.Ingredient)
                .Include(d => d.DishCategories)
                .ThenInclude(d => d.Category)
                .Include(d => d.Images);
        }
    }
}
