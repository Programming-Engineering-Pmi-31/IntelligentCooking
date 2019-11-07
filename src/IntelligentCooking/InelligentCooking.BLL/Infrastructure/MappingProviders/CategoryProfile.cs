using AutoMapper;
using InelligentCooking.BLL.DTOs;
using IntelligentCooking.Core.Entities;

namespace InelligentCooking.BLL.MappingProviders
{
    public class CategoryProfile: Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDto>()
                .ReverseMap();

            CreateMap<AddCategoryDto, Category>()
                .ReverseMap();
        }
    }
}
