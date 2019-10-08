using System.Collections.Generic;
using System.Threading.Tasks;
using IntelligentCooking.Core.Entities;
using IntelligentCooking.Core.Interfaces.Repositories;
using IntelligentCooking.DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace IntelligentCooking.DAL.Repositories
{
    public class DishRepository: NewRepository, IDishRepository
    {
        public DishRepository(IntelligentCookingContext context) : base(context) {}

        public Dish Add(Dish dish)
        {
            return Context.Dishes.Add(dish).Entity;
        }

        public async Task<IEnumerable<Dish>> GetDishesWithIngredientsCategoriesAndLikes()
        {
            return await Context.Dishes.Include(d => d.DishIngredients)
                .ThenInclude(di => di.Ingredient)
                .Include(d => d.DishCategories)
                .ThenInclude(d => d.Category)
                .ToListAsync();
        }
    }
}
