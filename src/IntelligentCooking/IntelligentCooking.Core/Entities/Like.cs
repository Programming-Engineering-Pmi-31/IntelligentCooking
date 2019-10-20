using IntelligentCooking.Core.Interfaces.Infrastructure;

namespace IntelligentCooking.Core.Entities
{
    public class Like: IIdentifiable<(int UserId, int DishId)>
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int DishId { get; set; }
        public Dish Dish { get; set; }

        public (int UserId, int DishId) Id => (UserId, DishId);
    }
}
