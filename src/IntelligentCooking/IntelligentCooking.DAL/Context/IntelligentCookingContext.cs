using System;
using IntelligentCooking.Core.Entities;
using IntelligentCooking.DAL.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace IntelligentCooking.DAL.Context
{
    class IntelligentCookingContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        //WILL BE REFACTORED TO USE CONNECTION STRING FROM CONFIG
        public IntelligentCookingContext(): base(GetOptions(@"Server=localhost\SQLEXPRESS;Database=IntelligentCooking;Trusted_Connection=True;"))
        {
        }

        private static DbContextOptions GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
        }

        public DbSet<Dish> Dishes { get; set; }
        public DbSet<DishCategory> DishCategories { get; set; }
        public DbSet<DishIngredient> DishIngredients { get; set; }
        public DbSet<Favourite> Favourites { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.SetConfigurations();
            modelBuilder.Seed();
        }
    }
}
