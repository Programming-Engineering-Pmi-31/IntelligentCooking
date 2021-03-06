﻿using AutoMapper;
using InelligentCooking.BLL.DTOs;
using IntelligentCooking.Core.Entities;

namespace InelligentCooking.BLL.MappingProviders
{
    public class IngredientProfile : Profile
    {
        public IngredientProfile()
        {
            CreateMap<Ingredient, IngredientDto>()
                .ReverseMap();

            CreateMap<Ingredient, IngredientDetailedDto>()
                .ReverseMap();

            CreateMap<AddIngredientDto, Ingredient>()
                .ForMember(x => x.Description, opts => opts.Ignore())
                .ReverseMap();
        }
    }
}
