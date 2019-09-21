using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using IntelligentCooking.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntelligentCooking.DAL.EntityConfigurations
{
    public class CategoryConfiguration: IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.CategoryId);

            builder.HasIndex(c => c.Name).IsUnique();

            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(30);

            builder.HasMany(c => c.DishCategories)
                .WithOne(dc => dc.Category)
                .IsRequired()
                .HasForeignKey(dc => dc.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);
        }        
    }
}
