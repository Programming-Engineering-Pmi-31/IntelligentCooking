using System.Collections.Generic;

namespace IntelligentCooking.Web.Models.RequestModels
{
    public class FilterRequest
    {
        public IEnumerable<int> IncludeIngredients { get; set; }

        public IEnumerable<int> ExcludeIngredients { get; set; }
    }
}
