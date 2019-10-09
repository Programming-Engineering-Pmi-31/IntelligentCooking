using System.Collections.Generic;
using IntelligentCooking.Core.Entities;

namespace IntelligentCooking.Core.Interfaces.Repositories
{
    public interface IDishCategoryRepository
    {
        void AddRange(IEnumerable<DishCategory> dishCategories);
    }
}
