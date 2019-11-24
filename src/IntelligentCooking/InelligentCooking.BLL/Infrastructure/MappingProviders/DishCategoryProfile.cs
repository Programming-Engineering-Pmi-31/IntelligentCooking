using AutoMapper;
using InelligentCooking.BLL.DTOs;
using IntelligentCooking.Core.Entities;

namespace InelligentCooking.BLL.MappingProviders
{
    public class DishCategoryProfile : Profile
    {
        public DishCategoryProfile()
        {
            CreateMap<DishCategory, CategoryDto>()
                .ForMember(i => i.Id, opt => opt.MapFrom(x => x.Category.Id))
                .ForMember(i => i.ImageUrl, opt => opt.MapFrom(x => x.Category.ImageUrl))
                .ForMember(i => i.Name, opt => opt.MapFrom(x => x.Category.Name));
        }
    }
}
