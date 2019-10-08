using IntelligentCooking.Core.Entities;
using IntelligentCooking.Core.Interfaces.Repositories;
using IntelligentCooking.DAL.Context;

namespace IntelligentCooking.DAL.Repositories
{
    public class DishIngredientRepository: Repository<DishIngredient>, IDishIngredientRepository
    {
        public DishIngredientRepository(IntelligentCookingContext context) : base(context) {}
    }
}
