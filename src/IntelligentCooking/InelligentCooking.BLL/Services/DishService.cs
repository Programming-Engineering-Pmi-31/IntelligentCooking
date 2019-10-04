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
    public class DishService: IDishService
    {

        private IIntelligentCookingUnitOfWork _unitOfWork;

        public DishService(IIntelligentCookingUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<DishPreviewDto>> GetDishesInfo()
        {
            var dishes = await _unitOfWork.Dishes.Get();

            var dishPreviews = new List<DishPreviewDto>();

            foreach (var d in dishes)
            {
                var tempDishPreviewDto = new DishPreviewDto()
                {
                    Id = d.Id,
                    Name = d.Name,
                    ImageUrl = d.ImageUrl,
                    Ingredients = (await _unitOfWork.DishIngredients.Get(di => di.DishId == d.Id, null, null, di => di.Ingredient))
                    .Select(di => di.Ingredient)
                    .Select(i => new IngredientDto { Id = i.Id, Name = i.Name }),
                    Categories = (await _unitOfWork.DishCategories.Get(dc => dc.DishId == d.Id, null, null, dc => dc.Category))
                    .Select(dc => dc.Category)
                    .Select(c => new CategoryDto { Id = c.Id, Name = c.Name }),
                    Rating = d.Stars,
                    Likes = (await _unitOfWork.Likes.Get()).Count(l => l.DishId == d.Id),
                    Time = d.Time,
                    Calories = d.Calories,
                    Servings = d.Servings,
                    Proteins = d.Proteins,
                    Carbohydrates = d.Carbohydrates,
                    Fats = d.Fats
                };
                dishPreviews.Add(tempDishPreviewDto);
            }





            //var likes = await _unitOfWork.Likes.Get();
            //var dishPreviews = dishes.Select(async (d) => new DishPreviewDto
            //{
            //    Id = d.Id,
            //    Name = d.Name,
            //    ImageUrl = d.ImageUrl,
            //    Ingredients = (await _unitOfWork.DishIngredients.Get(di => di.DishId == d.Id, null, null, di => di.Ingredient))
            //        .Select(di => di.Ingredient)
            //        .Select(i => new IngredientDto { Id = i.Id, Name = i.Name }),
            //    Categories = (await _unitOfWork.DishCategories.Get(dc => dc.DishId == d.Id, null, null, dc => dc.Category))
            //        .Select(dc => dc.Category)
            //        .Select(c => new CategoryDto { Id = c.Id, Name = c.Name }),
            //    Rating = d.Stars,
            //    Likes = (await _unitOfWork.Likes.Get()).Count(l => l.DishId == d.Id),
            //    //likes.Count(l => l.DishId == d.Id),
            //    Time = d.Time,
            //    Calories = d.Calories,
            //    Servings = d.Servings,
            //    Proteins = d.Proteins,
            //    Carbohydrates = d.Carbohydrates,
            //    Fats = d.Fats
            //}).ToList();

            return dishPreviews;
        }
    }
}
