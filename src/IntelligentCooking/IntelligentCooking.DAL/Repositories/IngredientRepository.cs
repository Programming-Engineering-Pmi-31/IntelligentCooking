using IntelligentCooking.Core.Entities;
using IntelligentCooking.Core.Interfaces.Repositories;
using IntelligentCooking.DAL.Context;

namespace IntelligentCooking.DAL.Repositories
{
    public class IngredientRepository: Repository<Ingredient, int>, IIngredientRepository
    {
        public IngredientRepository(IntelligentCookingContext context) : base(context) {}
    }
}
