using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using InelligentCooking.BLL.DTOs;
using InelligentCooking.BLL.Infrastructure.Exceptions;
using InelligentCooking.BLL.Interfaces;
using InelligentCooking.BLL.Models.ResponseModels;
using IntelligentCooking.Core.Entities;
using IntelligentCooking.Core.Interfaces.UnitsOfWork;

namespace InelligentCooking.BLL.Services
{
    public class FavouriteService: IFavouriteService
    {
        private readonly IIntelligentCookingUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FavouriteService(IIntelligentCookingUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        public async Task AddToFavouriteAsync(int dishId, int userId)
        {
            var favourite = await _unitOfWork.Favourites.FindAsync((userId, dishId));

            if(favourite != null)
                ExceptionHandler.DublicateObject(nameof(User), nameof(User.Favourites));

            _unitOfWork.Favourites.Add(new Favourite() {DishId = dishId, UserId = userId});
            await _unitOfWork.CommitAsync();
        }

        public async Task RemoveFromFavouriteAsync(int dishId, int userId)
        {
            var favourite = await _unitOfWork.Favourites.FindAsync((userId, dishId));

            if(favourite == null)
                ExceptionHandler.NotFound(nameof(Favourite));

            _unitOfWork.Favourites.Remove(favourite);
            await _unitOfWork.CommitAsync();
        }

        public async Task<DishPreviewResponse> GetFavouriteAsync(int userId)
        {
            var favourites = (await _unitOfWork.Favourites.GetWithDishesAsync(userId)).ToArray();
            return new DishPreviewResponse()
            {
                Dishes = favourites.Select(x => _mapper.Map<Dish, DishPreviewDto>(x.Dish)),
                Count = favourites.Length
            };
        }
    }
}
