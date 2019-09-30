using IntelligentCooking.Core.Entities;
using IntelligentCooking.Core.Interfaces.Repositories;
using IntelligentCooking.Core.Interfaces.UnitsOfWork;
using IntelligentCooking.DAL.Context;
using IntelligentCooking.DAL.Repositories;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace IntelligentCooking.Tests
{
    public class RepositoryTests
    {

        [Fact]
        public void Add()
        {
            var options = new DbContextOptionsBuilder<IntelligentCookingContext>()
                .UseInMemoryDatabase(databaseName: "Add")
                .Options;

            var context = new IntelligentCookingContext(options);

            var repo = new Repository<Ingredient, int>(context);

            repo.Add(new Ingredient() { Id = 1, Name = "sugar", Description = "sweet" });
            context.SaveChanges();

            Assert.Equal(1, context.Ingredients.Count());
            Assert.Equal("sugar", context.Ingredients.Single().Name);
        }

        [Fact]
        public void AddRange()
        {
            var options = new DbContextOptionsBuilder<IntelligentCookingContext>()
                .UseInMemoryDatabase(databaseName: "AddRange")
                .Options;

            var context = new IntelligentCookingContext(options);

            var repo = new Repository<Ingredient, int>(context);

            var ingredients = new List<Ingredient>()
            {
                new Ingredient() { Id = 1, Name = "sugar", Description = "sweet" },
                new Ingredient() { Id = 2, Name = "milk", Description = "cow" }
            };

            repo.AddRange(ingredients);
            context.SaveChanges();

            Assert.Equal(2, context.Ingredients.Count());
        }

        [Fact]
        public void Remove()
        {
            var options = new DbContextOptionsBuilder<IntelligentCookingContext>()
                 .UseInMemoryDatabase(databaseName: "Remove")
                 .Options;

            var context = new IntelligentCookingContext(options);

            var repo = new Repository<Ingredient, int>(context);

            repo.Add(new Ingredient() { Id = 1, Name = "sugar", Description = "sweet" });
            repo.Add(new Ingredient() { Id = 2, Name = "milk", Description = "cow" });
            repo.Add(new Ingredient() { Id = 3, Name = "water", Description = "blue" });
            context.SaveChanges();

            repo.Remove(context.Ingredients.Where(i => i.Id.Equals(1)).FirstOrDefault());
            context.SaveChanges();

            Assert.Equal(2, context.Ingredients.Count());
        }

        [Fact]
        public void RemoveRange()
        {
            var options = new DbContextOptionsBuilder<IntelligentCookingContext>()
                .UseInMemoryDatabase(databaseName: "RemoveRange")
                .Options;

            var context = new IntelligentCookingContext(options);

            var repo = new Repository<Ingredient, int>(context);

            var ingredients = new List<Ingredient>()
            {
                new Ingredient() { Id = 1, Name = "sugar", Description = "sweet" },
                new Ingredient() { Id = 2, Name = "milk", Description = "cow" },
                new Ingredient() { Id = 3, Name = "water", Description = "blue" },
                new Ingredient() { Id = 4, Name = "milk", Description = "plant" }
            };

            repo.AddRange(ingredients);
            context.SaveChanges();            

            repo.RemoveRange(context.Ingredients.Where(i => i.Name.Equals("milk")));
            context.SaveChanges();

            Assert.Equal(2, context.Ingredients.Count());
        }

        [Fact]
        public async void FindAsunc()
        {
            var options = new DbContextOptionsBuilder<IntelligentCookingContext>()
                .UseInMemoryDatabase(databaseName: "FindAsync")
                .Options;

            var context = new IntelligentCookingContext(options);

            var repo = new Repository<Ingredient, int>(context);

            var ingredients = new List<Ingredient>()
            {
                new Ingredient() { Id = 1, Name = "sugar", Description = "sweet" },
                new Ingredient() { Id = 2, Name = "milk", Description = "cow" },
                new Ingredient() { Id = 3, Name = "water", Description = "blue" },
                new Ingredient() { Id = 4, Name = "milk", Description = "plant" }
            };

            repo.AddRange(ingredients);
            context.SaveChanges();            

            Assert.Equal("sugar", (await repo.FindAsync(1)).Name);
        }

        [Fact]
        public async void GetOne()
        {
            var options = new DbContextOptionsBuilder<IntelligentCookingContext>()
                .UseInMemoryDatabase(databaseName: "GetOne")
                .Options;

            var context = new IntelligentCookingContext(options);

            var repo = new Repository<Ingredient, int>(context);

            var ingredients = new List<Ingredient>()
            {
                new Ingredient() { Id = 1, Name = "sugar", Description = "sweet" },
                new Ingredient() { Id = 2, Name = "milk", Description = "cow" },
                new Ingredient() { Id = 3, Name = "water", Description = "blue" },
                new Ingredient() { Id = 4, Name = "milk", Description = "plant" }
            };

            repo.AddRange(ingredients);
            context.SaveChanges();

            Assert.Equal(4, (await repo.GetOne(i => i.Name.Equals("milk") && i.Description.Equals("plant"))).Id);
        }

        [Fact]
        public async void Get()
        {
            var options = new DbContextOptionsBuilder<IntelligentCookingContext>()
                .UseInMemoryDatabase(databaseName: "Get")
                .Options;

            var context = new IntelligentCookingContext(options);

            var repo = new Repository<Ingredient, int>(context);

            var ingredients = new List<Ingredient>()
            {
                new Ingredient() { Id = 1, Name = "sugar", Description = "sweet" },
                new Ingredient() { Id = 2, Name = "milk", Description = "cow" },
                new Ingredient() { Id = 3, Name = "water", Description = "blue" },
                new Ingredient() { Id = 4, Name = "milk", Description = "plant" }
            };

            repo.AddRange(ingredients);
            context.SaveChanges();

            Assert.Equal(ingredients, (await repo.Get()));
        }

        [Fact]
        public async void GetPage()
        {
            var options = new DbContextOptionsBuilder<IntelligentCookingContext>()
                .UseInMemoryDatabase(databaseName: "GetPage")
                .Options;

            var context = new IntelligentCookingContext(options);

            var repo = new Repository<Ingredient, int>(context);

            var ingredients = new List<Ingredient>()
            {
                new Ingredient() { Id = 1, Name = "sugar", Description = "sweet" },
                new Ingredient() { Id = 2, Name = "milk", Description = "cow" }
            };

            repo.AddRange(ingredients);
            context.SaveChanges();

            Assert.Equal(ingredients, (await repo.Get(null, 0, 2)));
        }
    }
}
