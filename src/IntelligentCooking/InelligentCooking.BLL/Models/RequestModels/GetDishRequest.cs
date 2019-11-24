using InelligentCooking.BLL.Models.Enums;

namespace IntelligentCooking.Web.Models.RequestModels
{
    public class GetDishRequest
    {
        public int? Skip { get; set; }

        public int? Take { get; set; }

        public SortingCriteria? SortingCriteria { get; set; }

        public bool IsAscending { get; set; } = true;
    }
}
