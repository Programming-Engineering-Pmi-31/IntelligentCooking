using IntelligentCooking.Core.Interfaces.Infrastructure;

namespace IntelligentCooking.Core.Entities
{
    public class Rating : IIdentifiable<(int UserId, int DishId)>
    {
        public int UserId { get; set; }

        public User User { get; set; }

        public int DishId { get; set; }

        public Dish Dish { get; set; }

        public double Rate { get; set; }

        public (int UserId, int DishId) Id => (UserId, DishId);
    }
}
