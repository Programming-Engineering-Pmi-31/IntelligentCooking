using AutoMapper;
using InelligentCooking.BLL.DTOs;
using IntelligentCooking.Core.Entities;

namespace InelligentCooking.BLL.MappingProviders
{
    public class LikeProfile : Profile
    {
        public LikeProfile()
        {
            CreateMap<AddLikeDto, Like>();
        }
    }
}
