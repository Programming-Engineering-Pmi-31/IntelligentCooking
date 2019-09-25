using System;
using System.Collections.Generic;
using System.Text;
using IntelligentCooking.Core.Interfaces.Infrastructure;

namespace IntelligentCooking.Core.Entities
{
    public class Category: IIdentifiable<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<DishCategory> DishCategories { get; set; }
    }
}
