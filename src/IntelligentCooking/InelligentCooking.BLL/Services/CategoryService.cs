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
    public class CategoryService : ICategoryService
    {
        private IIntelligentCookingUnitOfWork _unitOfWork;

        public CategoryService(IIntelligentCookingUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<IEnumerable<CategoryDto>> GetCategories()
        {
            var categories = await _unitOfWork.Categories.GetAsync();

            return categories.Select(
                    c => new CategoryDto
                    {
                        Id = c.Id,
                        Name = c.Name,
                        ImageUrl = c.ImageUrl
                    })
                .ToList();
        }
    }
}
