using System.Threading.Tasks;
using InelligentCooking.BLL.DTOs;
using InelligentCooking.BLL.Interfaces;
using IntelligentCooking.Web.Infrastructure.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace IntelligentCooking.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LikeController : Controller
    {
        private readonly ILikeService _likeService;

        public LikeController(ILikeService likeService)
        {
            _likeService = likeService;
        }

        [HttpPost]
        public async Task<IActionResult> AddLike(AddLikeDto addLikeDto)
        {
            await _likeService.AddLikesForDishAsync(addLikeDto, this.GetContactId());
            return Ok();
        }
    }
}
