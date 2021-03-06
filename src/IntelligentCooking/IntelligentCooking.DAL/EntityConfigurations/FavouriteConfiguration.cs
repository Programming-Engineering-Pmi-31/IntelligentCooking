﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using IntelligentCooking.Core.Entities;

namespace IntelligentCooking.DAL.EntityConfigurations
{
    class FavouriteConfiguration: IEntityTypeConfiguration<Favourite>
    {
        public void Configure(EntityTypeBuilder<Favourite> builder)
        {
            builder.HasKey(f => new { f.UserId, f.DishId });
            builder.Ignore(dc => dc.Id);
        }
    }
}
