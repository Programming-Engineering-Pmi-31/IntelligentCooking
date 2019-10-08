using InelligentCooking.BLL.DTOs;
using InelligentCooking.BLL.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using IntelligentCooking.Core.Interfaces.UnitsOfWork;
using System.Linq;
using AutoMapper;
using IntelligentCooking.Core.Entities;

namespace InelligentCooking.BLL.Services
{
    public class DishService : IDishService
    {
        private IIntelligentCookingUnitOfWork _unitOfWork;
        private IImageService _imageService;
        private readonly IMapper _mapper;

        public DishService(
            IIntelligentCookingUnitOfWork unitOfWork,
            IImageService imageService,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _imageService = imageService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DishPreviewDto>> GetDishesInfo()
        {
            var dishes = await _unitOfWork.Dishes.GetDishesWithIngredientsCategoriesAndLikes();

            return dishes.Select(_mapper.Map<Dish, DishPreviewDto>)
                .ToArray();
        }

        public async Task AddDish(AddDishDto addDish)
        {
            var dish = _mapper.Map<AddDishDto, Dish>(addDish);

            dish.ImageUrl = await _imageService.UploadImageAsync(addDish.Img);

            var dishEntity = _unitOfWork.Dishes.Add(dish);

            var dishIngredients = addDish.Ingredients
                .Zip(addDish.IngredientAmounts, (i, a) => new {IngredientId = i, Amount = a})
                .Select(
                    x =>
                        new DishIngredient
                        {
                            DishId = dishEntity.Id,
                            IngredientId = x.IngredientId,
                            Amount = x.Amount
                        });

            _unitOfWork.DishIngredients.AddRange(dishIngredients);

            var dishCategories = addDish.Categories.Select(x => new DishCategory() {CategoryId = x, DishId = dishEntity.Id});
            _unitOfWork.DishCategories.AddRange(dishCategories);

            await _unitOfWork.CommitAsync();
        }
    }
}
