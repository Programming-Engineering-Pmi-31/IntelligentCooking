using AutoMapper;
using InelligentCooking.BLL.DTOs;
using IntelligentCooking.Core.Entities;

namespace InelligentCooking.BLL.MappingProviders
{
    public class RatingProfile : Profile
    {
        public RatingProfile()
        {
            CreateMap<AddRatingDto, Rating>();
        }
    }
}
