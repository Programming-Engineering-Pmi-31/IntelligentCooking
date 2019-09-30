using System;
using System.Threading;
using System.Threading.Tasks;
using IntelligentCooking.Core.Interfaces.UnitsOfWork;
using Microsoft.Extensions.DependencyInjection;

namespace IntelligentCooking.ConsoleDatabaseDemo
{
    class DataBaseDemo
    {
        private ServiceProvider _serviceProvider;
        private IIntelligentCookingUnitOfWork _unitOfWork;

        public DataBaseDemo()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddDataLayerDependecies(@"Server=.\SQLEXPRESS;Database=IntelligentCooking;Trusted_Connection=True;");
            _serviceProvider = serviceCollection.BuildServiceProvider(false);
            _unitOfWork = _serviceProvider.GetRequiredService<IIntelligentCookingUnitOfWork>();
        }

        public async Task Run()
        {
            Console.WriteLine("All Categories: \n");
            var categories = await _unitOfWork.Categories.Get();
            foreach (var category in categories)
            {
                Console.WriteLine("\tId : " + category.Id + "\tName: " + category.Name);
            }

            Console.WriteLine("\nAll Ingredients: \n");
            var ingredients = await _unitOfWork.Ingredients.Get();
            foreach (var ingredient in ingredients)
            {
                Console.WriteLine("\tId: " + ingredient.Id + "\tName: " + ingredient.Name + "\tDescription: " + ingredient.Description);
            }

            Console.WriteLine("\nAll Dishes: ");
            var dishes = await _unitOfWork.Dishes.Get();
            foreach (var dish in dishes)
            {
                Console.WriteLine("\n\tId: " + dish.Id + "\n\tName: " + dish.Name + "\n\tImageUrl: " + dish.ImageUrl + "\n\tRecipe: " + dish.Recipe + "\n\tTime: " + dish.Time + "\n\tServings: " + dish.Servings + "\tStars: " + dish.Stars + "\tProteins: " + dish.Proteins + "\tFats: " + dish.Fats + "\tCarbohydrates: " + dish.Carbohydrates + "\tCalories: " + dish.Calories + "\n\tDescription: " + dish.Description);
            }

            Console.WriteLine("\nAll DishIngredients: \n");
            var dishIngredients = await _unitOfWork.DishIngredients.Get();
            foreach (var dishIngredient in dishIngredients)
            {
                Console.WriteLine("\tId: " + dishIngredient.Id + "\tAmount: " + dishIngredient.Amount);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var demo = new DataBaseDemo();

            demo.Run();
            Console.ReadLine();
        }
    }
}
