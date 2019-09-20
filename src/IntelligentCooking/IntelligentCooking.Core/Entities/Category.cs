using System;
using System.Collections.Generic;
using System.Text;

namespace IntelligentCooking.Core.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }

        public ICollection<DishCategory> DishCategories { get; set; }
    }
}
