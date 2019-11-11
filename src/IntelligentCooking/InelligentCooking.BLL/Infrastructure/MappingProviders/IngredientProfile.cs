using AutoMapper;
using InelligentCooking.BLL.DTOs;
using IntelligentCooking.Core.Entities;

namespace InelligentCooking.BLL.MappingProviders
{
    public class IngredientProfile: Profile
    {
        public IngredientProfile()
        {
            CreateMap<Ingredient, IngredientDto>()
                .ReverseMap();
<<<<<<< HEAD

            CreateMap<AddIngredientDto, Ingredient>()
                .ReverseMap();
||||||| merged common ancestors
=======

            CreateMap<Ingredient, DetailedIngredientDto>()
                .ReverseMap();
>>>>>>> b0a998eca93ee776c8333ed287df14f2764d7871
        }
    }
}
