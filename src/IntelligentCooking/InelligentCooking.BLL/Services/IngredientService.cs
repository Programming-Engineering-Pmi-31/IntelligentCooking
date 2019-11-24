using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using InelligentCooking.BLL.DTOs;
using InelligentCooking.BLL.Infrastructure.Exceptions;
using InelligentCooking.BLL.Interfaces;
using IntelligentCooking.Core.Entities;
using IntelligentCooking.Core.Interfaces.UnitsOfWork;

namespace InelligentCooking.BLL.Services
{
    public class IngredientService : IIngredientService
    {
        private readonly IIntelligentCookingUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public IngredientService(IIntelligentCookingUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<IngredientDto>> GetIngredientsAsync()
        {
            var ingredients = await _unitOfWork.Ingredients.GetAsync();

            var ingredientsInfo = ingredients
                .Select(_mapper.Map<Ingredient, IngredientDto>)
                .ToList();

            return ingredientsInfo;
        }

        public async Task<IngredientDto> AddIngredientAsync(AddIngredientDto addIngredient)
        {
            if (await _unitOfWork.Ingredients.GetByNameAsync(addIngredient.Name) != null)
            {
                ExceptionHandler.DublicateObject(nameof(Ingredient), nameof(Ingredient.Name));
            }

            var ingredientEntity = _unitOfWork.Ingredients.Add(_mapper.Map<AddIngredientDto, Ingredient>(addIngredient));

            await _unitOfWork.CommitAsync();

            return _mapper.Map<Ingredient, IngredientDto>(ingredientEntity);
        }

        public async Task RemoveIngredientByIdAsync(int id)
        {
            var ingredient = await _unitOfWork.Ingredients.FindAsync(id);

            if (ingredient == null)
            {
                ExceptionHandler.NotFound(nameof(Ingredient));
            }

            _unitOfWork.Ingredients.Remove(ingredient);

            await _unitOfWork.CommitAsync();
        }
    }
}
