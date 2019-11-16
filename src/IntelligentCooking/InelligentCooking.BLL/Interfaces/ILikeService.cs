using System.Threading.Tasks;
using InelligentCooking.BLL.DTOs;

namespace InelligentCooking.BLL.Interfaces
{
    public interface ILikeService
    {
        Task AddLikesForDishAsync(AddLikeDto addLikeDto, int userId);
    }
}
