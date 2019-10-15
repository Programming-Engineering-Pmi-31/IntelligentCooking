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

        public async Task<IEnumerable<DishPreviewDto>> GetDishesInfo(MainGetDishDto getDish)
        {
            var dishes = await _unitOfWork.Dishes.GetDishesWithIngredientsCategoriesAndLikes(
                getDish.Skip,
                getDish.Take,
                getDish.ByTime,
                getDish.ByCalories);

            return dishes.Select(_mapper.Map<Dish, DishPreviewDto>)
                .ToArray();
        }

        public async Task<DishPreviewDto> AddDish(AddDishDto addDish)
        {
            var dish = _mapper.Map<AddDishDto, Dish>(addDish);

            var dishEntity = _unitOfWork.Dishes.Add(dish);

            var priority = 0;
            dish.Images = (await _imageService.UploadRangeAsync(addDish.Imgages)).Select(
                    url => new Image {Priority = priority++, DishId = dishEntity.Id, Url = url})
                .ToList();

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

            return _mapper.Map<Dish, DishPreviewDto>(dishEntity);
        }

        public async Task<DishDto> GetDishById(int id)
        {
            var dish = await _unitOfWork.Dishes.FindAsync(id);

            return _mapper.Map<Dish, DishDto>(dish);
        }
    }
}
