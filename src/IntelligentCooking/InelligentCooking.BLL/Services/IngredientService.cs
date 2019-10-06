using InelligentCooking.BLL.DTOs;
using InelligentCooking.BLL.Interfaces;
using IntelligentCooking.Core.Interfaces.UnitsOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InelligentCooking.BLL.Services
{
    public class IngredientService : IIngredientService
    {
        private IIntelligentCookingUnitOfWork _unitOfWork;

        public IngredientService(IIntelligentCookingUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<IEnumerable<IngredientDto>> GetIngredients()
        {
            var ingredients = await _unitOfWork.Ingredients.GetAsync();

            var ingredientsInfo = ingredients.Select(
                    c => new IngredientDto
                    {
                        Id = c.Id,
                        Name = c.Name
                    })
                .ToList();


            return ingredientsInfo;
        }
    }
}
