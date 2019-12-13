using System.Threading.Tasks;
using InelligentCooking.BLL.DTOs;
using InelligentCooking.BLL.Models.ResponseModels;

namespace InelligentCooking.BLL.Interfaces
{
    public interface IFavouriteService
    {
        Task AddToFavouriteAsync(int dishId, int userId);
        Task RemoveFromFavouriteAsync(int dishId, int userId);
        Task<DishPreviewResponse> GetFavouriteAsync(int userId);
    }
}
