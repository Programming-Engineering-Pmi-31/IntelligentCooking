﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using IntelligentCooking.Core.Entities;

namespace IntelligentCooking.DAL.EntityConfigurations
{
    public class DishIngredientConfiguration: IEntityTypeConfiguration<DishIngredient>
    {
        public void Configure(EntityTypeBuilder<DishIngredient> builder)
        {
            builder.HasKey(di => new { di.DishId, di.IngredientId });

            builder.Ignore(dc => dc.Id);

            builder.Property(di => di.Amount)
                .IsRequired();

        }
    }
}
