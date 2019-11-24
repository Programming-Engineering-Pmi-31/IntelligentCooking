using IntelligentCooking.Core.Entities;

namespace IntelligentCooking.Core.Interfaces.Repositories
{
    public interface IDishIngredientRepository : IRepository<DishIngredient, (int DishId, int IngredientId)>
    {
    }
}
