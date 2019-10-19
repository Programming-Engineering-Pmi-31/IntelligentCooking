using IntelligentCooking.Core.Interfaces.Infrastructure;

namespace IntelligentCooking.Core.Entities
{
    public class Image: IIdentifiable<(int DishId, int Priority)>
    {
        public int DishId { get; set; }
        public Dish Dish { get; set; }

        public int Priority { get; set; }
        public string Url { get; set; }

        public (int DishId, int Priority) Id => (DishId, Priority);
    }
}
