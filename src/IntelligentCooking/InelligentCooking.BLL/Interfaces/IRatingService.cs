using System.Threading.Tasks;
using InelligentCooking.BLL.DTOs;

namespace InelligentCooking.BLL.Interfaces
{
    public interface IRatingService
    {
        Task AddRatingForDishAsync(AddRatingDto addRatingDto, int userId);
    }
}
