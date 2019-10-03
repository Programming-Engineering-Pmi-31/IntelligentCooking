using InelligentCooking.BLL.DTOs;
using InelligentCooking.BLL.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Threading.Tasks;
using InelligentCooking.BLL.Infrastructure;
using IntelligentCooking.Core.Interfaces.UnitsOfWork;
using System.Linq;

namespace InelligentCooking.BLL.Services
{
    public class DishService: IDishService
    {

        private IIntelligentCookingUnitOfWork _unitOfWork;

        public DishService(IIntelligentCookingUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<DishPreviewDto>> GetDishesInfo()
        {
            var dishes = await _unitOfWork.Dishes.Get();
            var dishPreviews = dishes.Select(d => new DishPreviewDto 
                { DishId = d.Id, Name = d.Name, ImageUrl = d.ImageUrl}).ToList();
            return dishPreviews;
        }
    }
}
