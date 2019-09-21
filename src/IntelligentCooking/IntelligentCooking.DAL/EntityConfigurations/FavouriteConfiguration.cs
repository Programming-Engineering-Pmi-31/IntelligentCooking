using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using IntelligentCooking.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntelligentCooking.DAL.EntityConfigurations
{
    class FavouriteConfiguration: IEntityTypeConfiguration<Favourite>
    {
        public void Configure(EntityTypeBuilder<Favourite> builder)
        {
            builder.HasKey(f => new { f.UserId, f.DishId });
        }
    }
}
