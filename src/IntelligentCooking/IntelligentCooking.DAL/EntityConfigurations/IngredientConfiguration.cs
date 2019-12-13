using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using IntelligentCooking.Core.Entities;

namespace IntelligentCooking.DAL.EntityConfigurations
{
    public class IngredientConfiguration: IEntityTypeConfiguration<Ingredient>
    {
        public void Configure(EntityTypeBuilder<Ingredient> builder)
        {
            builder.HasKey(i => i.Id);

            builder.HasIndex(i => i.Name).IsUnique();

            builder.Property(i => i.Name)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(i => i.Description);

            builder.HasMany(i => i.DishIngredients)
                .WithOne(di => di.Ingredient)
                .IsRequired()
                .HasForeignKey(di => di.IngredientId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
