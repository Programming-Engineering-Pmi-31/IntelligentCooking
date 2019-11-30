using System;
using System.Globalization;
using System.Linq;
using AutoMapper;
using InelligentCooking.BLL.DTOs;
using IntelligentCooking.Core.Entities;

namespace InelligentCooking.BLL.MappingProviders
{
    public class DishProfile : Profile
    {
        public DishProfile()
        {
            CreateMap<Dish, DishPreviewDto>()
                .ForMember(d => d.Categories, opt => opt.MapFrom(x => x.DishCategories.Select(y => y.CategoryId)))
                .ForMember(d => d.Time, opt => opt.MapFrom(x => x.Time.ToString(Constants.Constants.TimeFormat)))
                .ForMember(d => d.Rating, opt => opt.MapFrom(x => x.Ratings.Count == 0 ? 0 : x.Ratings.Average(r => r.Rate)))
                .ForMember(d => d.RatesCount, opt => opt.MapFrom(x => x.Ratings.Count))
                .ForMember(
                    d => d.ImageUrl,
                    opt => opt.MapFrom(
                        x => x.Images.FirstOrDefault(z => z.Priority == 1)
                            .Url));

            CreateMap<AddDishDto, Dish>()
                .ForMember(d => d.Favourites, opt => opt.Ignore())
                .ForMember(d => d.Ratings, opt => opt.Ignore())
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.DishIngredients, opt => opt.Ignore())
                .ForMember(d => d.DishCategories, opt => opt.Ignore())
                .ForMember(d => d.Images, opt => opt.Ignore())
                .ForMember(d => d.Stars, opt => opt.MapFrom(x => 0))
                .ForMember(d => d.Time, opt => opt.MapFrom(x => TimeSpan.ParseExact(x.Time, Constants.Constants.TimeFormat, CultureInfo.InvariantCulture)));

            CreateMap<UpdateDishDto, Dish>()
               .ForMember(d => d.DishIngredients, opt => opt.Ignore())
               .ForMember(d => d.DishCategories, opt => opt.Ignore())
               .ForMember(d => d.Images, opt => opt.Ignore())
               .ForMember(d => d.Time, opt => opt.MapFrom(x => TimeSpan.ParseExact(x.Time, Constants.Constants.TimeFormat, CultureInfo.InvariantCulture)));

            CreateMap<Dish, DishDto>()
                .ForMember(d => d.Ingredients, opt => opt.MapFrom(x => x.DishIngredients))
                .ForMember(d => d.Categories, opt => opt.MapFrom(x => x.DishCategories))
                .ForMember(d => d.Time, opt => opt.MapFrom(x => x.Time.ToString(Constants.Constants.TimeFormat)))
                .ForMember(d => d.Images, opt => opt.MapFrom(x => x.Images))
                .ForMember(d => d.Rating, opt => opt.MapFrom(x => x.Ratings.Count == 0 ? 0 : x.Ratings.Average(r => r.Rate)))
                .ForMember(d => d.RatesCount, opt => opt.MapFrom(x => x.Ratings.Count));
        }
    }
}
