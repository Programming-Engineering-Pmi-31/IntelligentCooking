using System.Collections.Generic;
using System.Threading.Tasks;
using IntelligentCooking.Core.Entities;
using IntelligentCooking.Core.Interfaces.Repositories;
using IntelligentCooking.DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace IntelligentCooking.DAL.Repositories
{
    public class IngredientRepository: NewRepository, IIngredientRepository
    {
        public IngredientRepository(IntelligentCookingContext context) : base(context) {}

        public async Task<IEnumerable<Ingredient>> GetAsync()
        {
            return await Context.Ingredients.ToListAsync();
        }
    }
}
