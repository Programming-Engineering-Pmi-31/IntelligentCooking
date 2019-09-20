using IntelligentCooking.Core.Entities;
using IntelligentCooking.DAL.EntityConfigurations;
using IntelligentCooking.DAL.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntelligentCooking.DAL.Context
{
    class IntelligentCookingContext : DbContext
    {
        public IntelligentCookingContext():base(GetOptions(@"Server=localhost\SQLEXPRESS;Database=IntelligentCooking;Trusted_Connection=True;"))
        {

        }

    
        private static DbContextOptions GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<DishCategory> DishCategories { get; set; }
        public DbSet<DishIngredient> DishIngredients { get; set; }
        public DbSet<Favourite> Favourites { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.SetConfigurations();
            modelBuilder.Seed();
        }
    }
}
