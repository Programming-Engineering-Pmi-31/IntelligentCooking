using System.Collections.Generic;

namespace InelligentCooking.BLL.DTOs
{
    public class DishPreviewDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public double Rating { get; set; }
        public int RatesCount { get; set; }
        public string Time { get; set; }
        public int Servings { get; set; }
        public double Calories { get; set; }
        public double Proteins { get; set; }
        public double Fats { get; set; }
        public double Carbohydrates { get; set; }

        public IEnumerable<int> Categories { get; set; }
    }
}
