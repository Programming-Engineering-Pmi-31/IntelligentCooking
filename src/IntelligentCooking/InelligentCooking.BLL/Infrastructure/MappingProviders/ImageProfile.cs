using AutoMapper;
using InelligentCooking.BLL.DTOs;
using IntelligentCooking.Core.Entities;

namespace InelligentCooking.BLL.MappingProviders
{
    public class ImageProfile : Profile
    {
        public ImageProfile()
        {
            CreateMap<Image, ImageDto>()
                .ReverseMap();
        }
    }
}
