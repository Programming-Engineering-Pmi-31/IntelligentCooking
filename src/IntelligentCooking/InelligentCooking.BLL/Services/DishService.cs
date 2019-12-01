using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using InelligentCooking.BLL.DTOs;
using InelligentCooking.BLL.Infrastructure;
using InelligentCooking.BLL.Infrastructure.Exceptions;
using InelligentCooking.BLL.Infrastructure.Extensions;
using InelligentCooking.BLL.Interfaces;
using InelligentCooking.BLL.Models.Enums;
using InelligentCooking.BLL.Models.ResponseModels;
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

        public async Task<DishPreviewResponse> GetDishesInfoAsync(GetDishRequest getDish)
        {
            IEnumerable<Dish> dishes = null;

            switch(getDish.SortingCriteria)
            {
                case null:
                    dishes = await _unitOfWork.Dishes.GetDishesWithIngredientsCategoriesAndRatingsAsync(getDish.Skip, getDish.Take);
                    break;

                case SortingCriteria.Calories:
                    dishes = await _unitOfWork.Dishes.GetSortedDishesAsync(
                        d => d.Calories,
                        getDish.IsAscending,
                        getDish.Skip,
                        getDish.Take);

                    break;

                case SortingCriteria.Time:
                    dishes = await _unitOfWork.Dishes.GetSortedDishesAsync(
                        d => d.Time,
                        getDish.IsAscending,
                        getDish.Skip,
                        getDish.Take);

                    break;
            }

            var dishPrewiews = dishes.Select(_mapper.Map<Dish, DishPreviewDto>)
                .ToArray();

            return new DishPreviewResponse()
            {
                Dishes = dishPrewiews,
                Count = await _unitOfWork.Dishes.CountAsync()
            };
        }

        public async Task<DishPreviewResponse> GetDishesByCategoryAsync(int categoryId)
        {
            var dishes = (await _unitOfWork.Dishes.GetDishesWithIngredientsCategoriesAndRatingsAsync(null, null)).Where(
                    x => x.DishCategories.Any(c => c.CategoryId == categoryId))
                .ToArray();

            return new DishPreviewResponse()
            {
                Dishes = dishes.Select(_mapper.Map<Dish, DishPreviewDto>)
                    .ToArray(),
                Count = dishes.Count()
            };
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

        public async Task RemoveDishByIdAsync(int id)
        {
            var dish = await _unitOfWork.Dishes.FindAsync(id);

            if(dish == null)
            {
                ExceptionHandler.NotFound(nameof(Dish));
            }

            _unitOfWork.Dishes.Remove(dish);

            await _unitOfWork.CommitAsync();
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

        public async Task<DishDto> UpdateDishAsync(int id, UpdateDishDto updateDish)
        {
            var currentDish = await _unitOfWork.Dishes.GetByNameAsync(updateDish.Name);

            if(currentDish != null && !currentDish.Name.Equals(updateDish.Name))
            {
                ExceptionHandler.DublicateObject(nameof(Dish), nameof(Dish.Name));
            }

            var dishEntity = await _unitOfWork.Dishes.FindAsync(id);

            _mapper.Map(updateDish, dishEntity);

            dishEntity.Images = new List<Image>();

            if(updateDish.ImageUrls != null)
            {
                dishEntity.Images.AddRange(
                    updateDish.ImageUrls
                        .Select(img => new Image {Priority = img.Priority, DishId = dishEntity.Id, Url = img.Url})
                        .ToList());
            }

            if(updateDish.ImageFiles != null)
            {
                foreach(var img in updateDish.ImageFiles)
                {
                    dishEntity.Images.Add(
                        new Image
                        {
                            Priority = img.Priority,
                            DishId = dishEntity.Id,
                            Url = await _imageService.UploadImageAsync(img.File)
                        });
                }
            }

            var dishIngredients = updateDish.Ingredients
                .Zip(updateDish.IngredientAmounts, (i, a) => new { IngredientId = i, Amount = a })
                .Select(
                    x =>
                        new DishIngredient
                        {
                            DishId = dishEntity.Id,
                            IngredientId = x.IngredientId,
                            Amount = x.Amount
                        })
                .ToList();

            dishEntity.DishIngredients = dishIngredients;

            var dishCategories = updateDish.Categories.Select(
                    x => new DishCategory
                        {CategoryId = x, DishId = dishEntity.Id})
                .ToList();

            dishEntity.DishCategories = dishCategories;

            await _unitOfWork.CommitAsync();

            return _mapper.Map<Dish, DishDto>(await _unitOfWork.Dishes.FindAsync(id));
        }

        public async Task<IEnumerable<DishPreviewDto>> GetDishesByIngredients(FilterRequest filterRequest)
        {
            var dishComparer = GenericEqualityComparer<Dish>.GetEqualityComparer((d1, d2) => d1.Id == d2.Id, d => d.Id);

            var query = (await (filterRequest.IncludeIngredients?.Any() ?? false
                ? _unitOfWork.Dishes.GetByIngredientsAsync(filterRequest.IncludeIngredients)
                : _unitOfWork.Dishes.GetDishesWithIngredientsCategoriesAndRatingsAsync(null, null))).AsQueryable();

            query = query.Where(d => d.Name.IndexOf(filterRequest.Name, StringComparison.InvariantCultureIgnoreCase) != -1);

            query = filterRequest.ExcludeIngredients?.Any() ?? false
                ? query.Except(await _unitOfWork.Dishes.GetByIngredientsAsync(filterRequest.ExcludeIngredients), dishComparer)
                : query;


            query = filterRequest.IncludeIngredients?.Any() ?? false
                ? query.Where(
                    res => res.DishIngredients.Select(di => di.IngredientId)
                               .Intersect(filterRequest.IncludeIngredients)
                               .Count()
                           / (double)filterRequest.IncludeIngredients.Count()
                           >= 0.5)
                : query;

            return query.Select(_mapper.Map<Dish, DishPreviewDto>)
                .ToList();
        }

        public async Task<IEnumerable<DishPreviewDto>> GetTopDishesInfoAsync(int amount)
        {
            var dishes = await _unitOfWork.Dishes.GetTop(amount);

            return dishes.Select(_mapper.Map<Dish, DishPreviewDto>)
                .ToArray();
        }
    }
}
