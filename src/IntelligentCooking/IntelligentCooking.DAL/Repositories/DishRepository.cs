using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using IntelligentCooking.Core.Entities;
using IntelligentCooking.Core.Interfaces.Repositories;
using IntelligentCooking.DAL.Context;
using IntelligentCooking.DAL.Extensions;
using Microsoft.EntityFrameworkCore;

namespace IntelligentCooking.DAL.Repositories
{
    public class DishRepository : Repository<Dish, int>, IDishRepository
    {
        public DishRepository(IntelligentCookingContext context) : base(context) { }

        public async Task<IEnumerable<Dish>> GetDishesWithIngredientsCategoriesAndLikesAsync<T>(Expression<Func<Dish, T>> filter, bool ascending, int? skip, int? take)
        {
            var dishes = Context.Dishes
                 .Include(d => d.DishIngredients)
                 .ThenInclude(di => di.Ingredient)
                 .Include(d => d.DishCategories)
                 .ThenInclude(d => d.Category)
                 .Include(d => d.Images)
                 .AsQueryable();

            dishes = ascending ? dishes.OrderBy(filter) : dishes.OrderByDescending(filter);

            if (skip.HasValue && take.HasValue)
            {
                dishes = dishes.Paginate(skip.Value, take.Value);
            }

            return await dishes.ToListAsync();
        }

        public async Task<Dish> GetByNameAsync(string name)
        {
            return await Context.Dishes.FirstOrDefaultAsync(x => x.Name.Equals(name));
        }

        public override async Task<Dish> FindAsync(int id)
        {
            return await Context.Dishes
                .Include(d => d.DishIngredients)
                .ThenInclude(di => di.Ingredient)
                .Include(d => d.DishCategories)
                .ThenInclude(d => d.Category)
                .Include(d => d.Images)
                .Include(d => d.Likes)
                .FirstOrDefaultAsync(d => d.Id == id);
        }
    }
}
