using IntelligentCooking.Core.Entities;
using IntelligentCooking.Core.Interfaces.Repositories;
using IntelligentCooking.DAL.Context;

namespace IntelligentCooking.DAL.Repositories
{
    public class FavouriteRepository: Repository<Favourite, (int UserId, int DishId)>, IFavouriteRepository
    {
        public FavouriteRepository(IntelligentCookingContext context) : base(context) {}
    }
}
