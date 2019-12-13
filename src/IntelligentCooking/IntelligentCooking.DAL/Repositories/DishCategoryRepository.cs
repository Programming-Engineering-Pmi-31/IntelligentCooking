using IntelligentCooking.Core.Entities;
using IntelligentCooking.Core.Interfaces.Repositories;
using IntelligentCooking.DAL.Context;

namespace IntelligentCooking.DAL.Repositories
{
    public class DishCategoryRepository: Repository<DishCategory, (int DishId, int CategoryId)>, IDishCategoryRepository
    {
        public DishCategoryRepository(IntelligentCookingContext context) : base(context) {}
    }
}
