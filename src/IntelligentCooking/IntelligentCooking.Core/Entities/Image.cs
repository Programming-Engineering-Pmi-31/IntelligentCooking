namespace IntelligentCooking.Core.Entities
{
    public class Image
    {
        public int DishId { get; set; }
        public Dish Dish { get; set; }

        public int Priority { get; set; }
        public string Url { get; set; }
    }
}
