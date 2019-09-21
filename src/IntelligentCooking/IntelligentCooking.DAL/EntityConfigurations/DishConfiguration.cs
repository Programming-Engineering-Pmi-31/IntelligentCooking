using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using IntelligentCooking.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntelligentCooking.DAL.EntityConfigurations
{
    public class DishConfiguration: IEntityTypeConfiguration<Dish>
    {
        public void Configure(EntityTypeBuilder<Dish> builder)
        {
            builder.HasKey(d => d.DishId);

            builder.HasIndex(d => d.Name).IsUnique();

            builder.Property(d => d.Name)                
                .IsRequired()
                .HasMaxLength(40);                

            builder.Property(d => d.ImageUrl)
                .IsRequired();

            builder.Property(d => d.Recipe)
                .IsRequired();

            builder.Property(d => d.Description)
                .IsRequired();

            builder.HasMany(d => d.DishIngredients)
                .WithOne(di => di.Dish)
                .IsRequired()
                .HasForeignKey(di => di.DishId);

            builder.HasMany(d => d.DishCategories)
                .WithOne(dc => dc.Dish)
                .IsRequired()
                .HasForeignKey(dc => dc.DishId);

            builder.HasMany(d => d.Likes)
                .WithOne(l => l.Dish)
                .IsRequired()
                .HasForeignKey(l => l.DishId);

            builder.HasMany(d => d.Favourites)
                .WithOne(f => f.Dish)
                .IsRequired()
                .HasForeignKey(f => f.DishId);
        }
    }
}
