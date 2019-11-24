using System.Collections.Generic;
using IntelligentCooking.Core.Interfaces.Infrastructure;

namespace IntelligentCooking.Core.Entities
{
    public class Category : IIdentifiable<int>
    {
        public Category()
        {
            DishCategories = new HashSet<DishCategory>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public ICollection<DishCategory> DishCategories { get; set; }
    }
}
