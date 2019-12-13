using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InelligentCooking.BLL.Interfaces;
using InelligentCooking.BLL.Models.ResponseModels;
using IntelligentCooking.Web.Infrastructure.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IntelligentCooking.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class FavouriteController : Controller
    {
        private readonly IFavouriteService _favouriteService;

        public FavouriteController(IFavouriteService favouriteService)
        {
            _favouriteService = favouriteService;
        }

        [HttpGet()]
        public async Task<DishPreviewResponse> GetFavouriteAsync()
        {
            return await _favouriteService.GetFavouriteAsync(this.GetContactId());
        }

        [HttpPost]
        public async Task AddToFavouriteAsync(int dishId)
        {
            await _favouriteService.AddToFavouriteAsync(dishId, this.GetContactId());
        }

        [HttpDelete]
        public async Task RemoveFromFavouriteAsync(int dishId)
        {
            await _favouriteService.RemoveFromFavouriteAsync(dishId, this.GetContactId());
        }
    }
}