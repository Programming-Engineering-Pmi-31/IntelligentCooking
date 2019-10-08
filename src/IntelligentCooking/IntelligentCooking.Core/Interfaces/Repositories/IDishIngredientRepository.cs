using System.Collections.Generic;
using IntelligentCooking.Core.Entities;

namespace IntelligentCooking.Core.Interfaces.Repositories
{
    public interface IDishIngredientRepository
    {
        void AddRange(IEnumerable<DishIngredient> dishIngredients);
    }
}
