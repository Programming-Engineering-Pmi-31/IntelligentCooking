using System;
using System.Globalization;
using System.Linq;
using AutoMapper;
using InelligentCooking.BLL.DTOs;
using IntelligentCooking.Core.Entities;

namespace InelligentCooking.BLL.MappingProviders
{
    public class DishProfile: Profile
    {
        public DishProfile()
        {
            CreateMap<Dish, DishPreviewDto>()
                .ForMember(d => d.Categories, opt => opt.MapFrom(x => x.DishCategories.Select(y=>y.CategoryId)))
                .ForMember(d => d.Time, opt => opt.MapFrom(x => x.Time.ToShortTimeString()))
                .ForMember(d => d.Likes, opt => opt.MapFrom(x => x.Likes.Count))
                .ForMember(d => d.ImageUrl, opt => opt.MapFrom(x => x.Images.FirstOrDefault(z => z.Priority == 1).Url));

            CreateMap<AddDishDto, Dish>()
                .ForMember(d => d.Favourites, opt => opt.Ignore())
                .ForMember(d => d.Likes, opt => opt.Ignore())
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.DishIngredients, opt => opt.Ignore())
                .ForMember(d => d.DishCategories, opt => opt.Ignore())
                .ForMember(d => d.Stars, opt => opt.MapFrom(x => 0))
                .ForMember(d => d.Name, opt => opt.MapFrom(x => x.Title))
                .ForMember(d => d.Carbohydrates, opt => opt.MapFrom(x => x.Carbs))
                .ForMember(d => d.Time, opt => opt.MapFrom(x => DateTime.ParseExact(x.Time, "HH:mm", CultureInfo.InvariantCulture)))
                .ForMember(d => d.Calories, opt => opt.MapFrom(x => x.Cals));

            CreateMap<Dish, DishDto>()
                .ForMember(d => d.Ingredients, opt => opt.MapFrom(x => x.DishIngredients))
                .ForMember(d => d.Categories, opt => opt.MapFrom(x => x.DishCategories))
                .ForMember(d => d.Time, opt => opt.MapFrom(x => x.Time.ToShortTimeString()))
                .ForMember(d => d.Images, opt => opt.MapFrom(x => x.Images))
                .ForMember(d => d.Likes, opt => opt.MapFrom(x => x.Likes.Count));
        }
    }
}
