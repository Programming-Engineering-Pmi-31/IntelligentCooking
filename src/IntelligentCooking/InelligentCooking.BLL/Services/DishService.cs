using InelligentCooking.BLL.DTOs;
using InelligentCooking.BLL.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Threading.Tasks;
using InelligentCooking.BLL.Infrastructure;
using IntelligentCooking.Core.Interfaces.UnitsOfWork;
using System.Linq;
using IntelligentCooking.Core.Entities;

namespace InelligentCooking.BLL.Services
{
    public class DishService : IDishService
    {
        private IIntelligentCookingUnitOfWork _unitOfWork;
        private IImageService _imageService;

        public DishService(IIntelligentCookingUnitOfWork unitOfWork, IImageService imageService)
        {
            _unitOfWork = unitOfWork;
            _imageService = imageService;
        }

        public async Task<IEnumerable<DishPreviewDto>> GetDishesInfo()
        {
            var dishes = await _unitOfWork.Dishes.GetDishesWithIngredientsCategoriesAndLikes();

            return dishes.Select(
                    d => new DishPreviewDto
                    {
                        Id = d.Id,
                        Name = d.Name,
                        ImageUrl = d.ImageUrl,
                        Ingredients = d.DishIngredients.Select(
                            di => new IngredientDto
                            {
                                Id = di.IngredientId,
                                Name = di.Ingredient.Name
                            }),
                        Categories = d.DishCategories.Select(
                            dc => new CategoryDto
                            {
                                Id = dc.CategoryId,
                                Name = dc.Category.Name,
                                ImageUrl = dc.Category.ImageUrl
                            }),
                        Rating = d.Stars,
                        Likes = d.Likes.Count,
                        Time = d.Time,
                        Calories = d.Calories,
                        Servings = d.Servings,
                        Proteins = d.Proteins,
                        Carbohydrates = d.Carbohydrates,
                        Fats = d.Fats
                    })
                .ToArray();
        }

        public async Task AddDish(AddDishDto addDish)
        {
            var dish = new Dish
            {
                Name = addDish.Title,
                ImageUrl = await _imageService.UploadImageAsync(addDish.Img),
                Recipe = addDish.Recipe,
                Time = addDish.Time,
                Servings = addDish.Servings,
                Proteins = addDish.Proteins,
                Fats = addDish.Fats,
                Carbohydrates = addDish.Carbs,
                Calories = addDish.Cals,
                Description = addDish.Description,
            };

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
