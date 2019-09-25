using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using IntelligentCooking.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntelligentCooking.DAL.EntityConfigurations
{
    public class DishIngredientConfiguration: IEntityTypeConfiguration<DishIngredient>
    {
        public void Configure(EntityTypeBuilder<DishIngredient> builder)
        {
            builder.HasKey(di => new { di.DishId, di.IngredientId });

            builder.Property(di => di.Amount)
                .IsRequired();

            builder.Ignore(x => x.Id);
        }
    }
}
