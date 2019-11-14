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
<<<<<<< HEAD
||||||| merged common ancestors
<<<<<<<<< Temporary merge branch 1
=======
>>>>>>> 69c9461f09edacf08622d073eca781a64aacc3a9

<<<<<<< HEAD
            CreateMap<AddIngredientDto, Ingredient>()
||||||| merged common ancestors
            CreateMap<Ingredient, DetailedIngredientDto>()
=======
            CreateMap<Ingredient, IngredientDetailedDto>()
>>>>>>> 69c9461f09edacf08622d073eca781a64aacc3a9
                .ReverseMap();
<<<<<<< HEAD
||||||| merged common ancestors
=======

            CreateMap<Ingredient, DetailedIngredientDto>()
                .ReverseMap();
>>>>>>> b0a998eca93ee776c8333ed287df14f2764d7871
||||||| merged common ancestors
||||||||| merged common ancestors
=========

            CreateMap<AddIngredientDto, Ingredient>()
                .ReverseMap();
>>>>>>>>> Temporary merge branch 2
=======
>>>>>>> 69c9461f09edacf08622d073eca781a64aacc3a9
        }
    }
}
