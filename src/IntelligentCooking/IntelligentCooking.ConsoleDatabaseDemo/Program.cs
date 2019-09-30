using System;
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
            var category = await _unitOfWork.Categories.FindAsync(1);
            Console.WriteLine(category.Name);
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
