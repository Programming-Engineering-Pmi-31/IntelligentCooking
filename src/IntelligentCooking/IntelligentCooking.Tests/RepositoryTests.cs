using IntelligentCooking.Core.Entities;
using IntelligentCooking.Core.Interfaces.Repositories;
using IntelligentCooking.Core.Interfaces.UnitsOfWork;
using IntelligentCooking.DAL.Context;
using IntelligentCooking.DAL.Repositories;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using Xunit;

namespace IntelligentCooking.Tests
{
    public class RepositoryTests
    {
        private ServiceProvider _services;

        public RepositoryTests()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddDataLayerDependecies("DataSource=:memory:");
            _services = serviceCollection.BuildServiceProvider(false);
        }

        [Fact]
        public void Add_writes_to_database()
        {
            var unitOfWork = _services.GetRequiredService<IIntelligentCookingUnitOfWork>();
            //var ing = unitOfWork.Ingredients.
        }
    }
}
