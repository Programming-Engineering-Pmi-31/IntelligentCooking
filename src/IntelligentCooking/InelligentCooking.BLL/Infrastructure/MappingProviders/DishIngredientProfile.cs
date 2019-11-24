using AutoMapper;
using InelligentCooking.BLL.DTOs;
using IntelligentCooking.Core.Entities;

namespace InelligentCooking.BLL.MappingProviders
{
    public class DishIngredientProfile : Profile
    {
        public DishIngredientProfile()
        {
            CreateMap<DishIngredient, IngredientDto>()
                .ForMember(i => i.Id, opt => opt.MapFrom(x => x.Ingredient.Id))
                .ForMember(i => i.Name, opt => opt.MapFrom(x => x.Ingredient.Name));

            CreateMap<DishIngredient, IngredientDetailedDto>()
                .ForMember(i => i.Id, opt => opt.MapFrom(x => x.Ingredient.Id))
                .ForMember(i => i.Name, opt => opt.MapFrom(x => x.Ingredient.Name))
                .ForMember(i => i.Amount, opt => opt.MapFrom(x => x.Amount));
        }
    }
}
