using InelligentCooking.BLL.DTOs;
using InelligentCooking.BLL.Interfaces;
using IntelligentCooking.Core.Entities;
using IntelligentCooking.Core.Interfaces.UnitsOfWork;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using InelligentCooking.BLL.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Http;

namespace InelligentCooking.BLL.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IIntelligentCookingUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IImageService _imageService;

        public CategoryService(IIntelligentCookingUnitOfWork unitOfWork, IMapper mapper, IImageService imageService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _imageService = imageService;
        }

        public async Task<IEnumerable<CategoryDto>> GetCategoriesAsync()
        {
            var categories = await _unitOfWork.Categories.GetAsync();

            return categories.Select(_mapper.Map<Category, CategoryDto>)
                .ToList();
        }


        public async Task<CategoryDto> AddCategoryAsync(AddCategoryDto addCategory)
        {
            if (await _unitOfWork.Categories.GetByNameAsync(addCategory.Name) != null)
            {
                ExceptionHandler.DublicateObject(nameof(Category), nameof(Category.Name));
            }

            var categoryEntity = _unitOfWork.Categories.Add(_mapper.Map<AddCategoryDto, Category>(addCategory));

            categoryEntity.ImageUrl = await _imageService.UploadImageAsync(addCategory.Image);

            await _unitOfWork.CommitAsync();

            return _mapper.Map<Category, CategoryDto>(categoryEntity);
        }

        public async Task RemoveCategoryByIdAsync(int id)
        {
            var category = await _unitOfWork.Categories.FindAsync(id);

            if (category == null)
            {
                ExceptionHandler.NotFound(nameof(Category));
            }

            _unitOfWork.Categories.Remove(category);

            await _unitOfWork.CommitAsync();
        }

    }
}
