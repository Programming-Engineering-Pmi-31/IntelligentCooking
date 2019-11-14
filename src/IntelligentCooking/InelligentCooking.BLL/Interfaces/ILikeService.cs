using System.Threading.Tasks;
using InelligentCooking.BLL.DTOs;

namespace InelligentCooking.BLL.Interfaces
{
    public interface ILikeService
    {
        Task<double> GetLikesForDishAsync(int dishId);
        Task AddLikesForDishAsync(AddLikeDto addLikeDto, int userId);
    }
}
