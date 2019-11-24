using IntelligentCooking.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IntelligentCooking.DAL.EntityConfigurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);

            builder.HasIndex(c => c.Name).IsUnique();

            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(c => c.ImageUrl)
                .IsRequired();

            builder.HasMany(c => c.DishCategories)
                .WithOne(dc => dc.Category)
                .IsRequired()
                .HasForeignKey(dc => dc.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
