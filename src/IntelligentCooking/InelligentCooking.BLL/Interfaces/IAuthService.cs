using System.Threading.Tasks;
using InelligentCooking.BLL.Models.ResponseModels;
using IntelligentCooking.Web.Models.RequestModels;

namespace InelligentCooking.BLL.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResponse> RegisterAsync(UserRegistrationRequest registrationRequest);
        Task<AuthResponse> LoginAsync(UserLoginRequest loginRequest);
    }
}
