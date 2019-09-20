using System;
using System.Collections.Generic;
using System.Text;

namespace IntelligentCooking.Core.Entities
{
    public class Favourite
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int DishId { get; set; }
        public Dish Dish { get; set; }
    }
}
