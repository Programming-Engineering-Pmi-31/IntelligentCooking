using System.Threading.Tasks;
using InelligentCooking.BLL.DTOs;
using InelligentCooking.BLL.Models.ResponseModels;

namespace InelligentCooking.BLL.Interfaces
{
    public interface IRatingService
    {
        Task<RateResponse> AddRatingForDishAsync(AddRatingDto addRatingDto, int userId);
    }
}
