using InelligentCooking.BLL.DTOs;
using InelligentCooking.BLL.Interfaces;
using IntelligentCooking.Core.Interfaces.UnitsOfWork;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using IntelligentCooking.Core.Entities;

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
    }
}
