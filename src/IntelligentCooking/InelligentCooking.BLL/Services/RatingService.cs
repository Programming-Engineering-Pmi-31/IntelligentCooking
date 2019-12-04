using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using InelligentCooking.BLL.DTOs;
using InelligentCooking.BLL.Infrastructure.Exceptions;
using InelligentCooking.BLL.Interfaces;
using InelligentCooking.BLL.Models.ResponseModels;
using IntelligentCooking.Core.Entities;
using IntelligentCooking.Core.Interfaces.UnitsOfWork;

namespace InelligentCooking.BLL.Services
{
    public class RatingService: IRatingService
    {
        private readonly IIntelligentCookingUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RatingService(IIntelligentCookingUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<RateResponse> AddRatingForDishAsync(AddRatingDto addRatingDto, int userId)
        {
            var rating = await _unitOfWork.Ratings.FindAsync((userId, addRatingDto.DishId));

            if (rating != null)
            {
                rating.Rate = addRatingDto.Rate;
            }
            else
            {
                var newRating = _mapper.Map<Rating>(addRatingDto);

                newRating.UserId = userId;
                _unitOfWork.Ratings.Add(newRating);
            }           

            await _unitOfWork.CommitAsync();

            return new RateResponse()
            {
                IsNewRate = rating == null
            };
        }
    }
}
