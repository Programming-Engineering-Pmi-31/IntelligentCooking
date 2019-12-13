using IntelligentCooking.Core.Entities;
using IntelligentCooking.Core.Interfaces.Repositories;
using IntelligentCooking.DAL.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace IntelligentCooking.DAL.Repositories
{
    public class IngredientRepository: Repository<Ingredient, int>, IIngredientRepository
    {
        public IngredientRepository(IntelligentCookingContext context) : base(context) {}

        public async Task<Ingredient> GetByNameAsync(string name)
        {
            return await Context.Ingredients.FirstOrDefaultAsync(x => x.Name.Equals(name));
        }
    }
}
