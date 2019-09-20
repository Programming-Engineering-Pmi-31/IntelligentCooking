using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using IntelligentCooking.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntelligentCooking.DAL.EntityConfigurations
{
    public class UserConfiguration: IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.UserId);

            builder.HasIndex(u => u.Login).IsUnique();

            builder.Property(u => u.Login)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(u => u.Email)
                    .IsRequired()
                    .HasMaxLength(30);

            builder.Property(u => u.Password)
                    .IsRequired()
                    .HasMaxLength(30);

            builder.HasMany(u => u.Likes)
                .WithOne(l => l.User)
                .IsRequired()
                .HasForeignKey(l => l.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(u => u.Favourites)
                .WithOne(f => f.User)
                .IsRequired()
                .HasForeignKey(f => f.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }        
    }
}
