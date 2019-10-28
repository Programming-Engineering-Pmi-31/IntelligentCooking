using InelligentCooking.BLL.DTOs;
using InelligentCooking.BLL.Interfaces;
using IntelligentCooking.Core.Entities;
using IntelligentCooking.Core.Interfaces.UnitsOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace InelligentCooking.BLL.Services
{
    public class CategoryService : ICategoryService
    {
        private IIntelligentCookingUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryService(IIntelligentCookingUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryDto>> GetCategoriesAsync()
        {
            var categories = await _unitOfWork.Categories.GetAsync();

            return categories.Select(_mapper.Map<Category, CategoryDto>)
                .ToList();
        }

    }
}
