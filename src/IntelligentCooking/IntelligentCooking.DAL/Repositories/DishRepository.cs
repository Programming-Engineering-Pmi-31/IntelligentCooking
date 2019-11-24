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

        public async Task<IEnumerable<Dish>> GetDishesWithIngredientsCategoriesAndRatingsAsync(int? skip, int? take)
        {
            var dishes = GetWithMainPageProps();           

            if (skip.HasValue && take.HasValue)
            {
                dishes = dishes.Paginate(skip.Value, take.Value);
            }

            return await dishes.ToListAsync();
        }

        public async Task<IEnumerable<Dish>> GetSortedDishesAsync<T>(Expression<Func<Dish, T>> predicate, bool ascending, int? skip, int? take)
        {
            var dishes = GetWithMainPageProps();

            dishes = ascending ? dishes.OrderBy(predicate) : dishes.OrderByDescending(predicate);

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
                .Include(d => d.Ratings)
                .FirstOrDefaultAsync(d => d.Id == id);
        }   

        private IQueryable<Dish> GetWithMainPageProps()
        {
            return Context.Dishes
                 .Include(d => d.DishIngredients)
                 .ThenInclude(di => di.Ingredient)
                 .Include(d => d.DishCategories)
                 .ThenInclude(d => d.Category)
                 .Include(d => d.Images)
                 .Include(d => d.Ratings)
                 .AsQueryable();
        }

        public async Task<IEnumerable<Dish>> GetTop(int amount)
        {
            return await GetWithMainPageProps()                
                .Where(d => d.Ratings.Count != 0)
                .OrderByDescending(d => d.Ratings.Average(r => r.Rate))                
                .Take(amount)
                .ToListAsync();
        }
    }
}
