using IntelligentCooking.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IntelligentCooking.DAL.EntityConfigurations
{
    public class DishCategoryConfiguration : IEntityTypeConfiguration<DishCategory>
    {
        public void Configure(EntityTypeBuilder<DishCategory> builder)
        {
            builder.HasKey(dc => new { dc.CategoryId, dc.DishId });
            builder.Ignore(dc => dc.Id);
        }
    }
}
