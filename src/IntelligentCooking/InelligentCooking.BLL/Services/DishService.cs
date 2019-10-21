using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using InelligentCooking.BLL.DTOs;
using InelligentCooking.BLL.Infrastructure.Exceptions;
using InelligentCooking.BLL.Interfaces;
using IntelligentCooking.Core.Entities;
using IntelligentCooking.Core.Interfaces.UnitsOfWork;
using IntelligentCooking.Web.Models.RequestModels;

namespace InelligentCooking.BLL.Services
{
    public class DishService : IDishService
    {
        private readonly IIntelligentCookingUnitOfWork _unitOfWork;
        private readonly IImageService _imageService;
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

        public async Task<IEnumerable<DishPreviewDto>> GetDishesInfoAsync(GetDishRequest getDish)
        {
            var dishes = await _unitOfWork.Dishes.GetDishesWithIngredientsCategoriesAndLikesAsync(getDish.Skip, getDish.Take);

            return dishes.Select(_mapper.Map<Dish, DishPreviewDto>)
                .ToArray();
        }

        public async Task<DishDto> AddDishAsync(AddDishDto addDish)
        {
            if(await _unitOfWork.Dishes.GetByNameAsync(addDish.Name) != null)
            {
                ExceptionHandler.DublicateObject(nameof(Dish), nameof(Dish.Name));
            }

            var dishEntity = _unitOfWork.Dishes.Add(_mapper.Map<AddDishDto, Dish>(addDish));

            var priority = 1;
            dishEntity.Images = (await _imageService.UploadRangeAsync(addDish.Images))
                .Select(url => new Image {Priority = priority++, DishId = dishEntity.Id, Url = url})
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

            var dishCategories = addDish.Categories.Select(
                x => new DishCategory
                    {CategoryId = x, DishId = dishEntity.Id});

            _unitOfWork.DishCategories.AddRange(dishCategories);

            await _unitOfWork.CommitAsync();

            return _mapper.Map<Dish, DishDto>(dishEntity);
        }

        public async Task<DishDto> FindByIdAsync(int id)
        {
            var dish = await _unitOfWork.Dishes.FindAsync(id);

            if(dish == null)
            {
                ExceptionHandler.NotFound(nameof(Dish));
            }

            return _mapper.Map<Dish, DishDto>(dish);
        }
    }
}
