using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using IntelligentCooking.Core.Entities;

namespace IntelligentCooking.DAL.EntityConfigurations
{
    public class DishCategoryConfiguration: IEntityTypeConfiguration<DishCategory>
    {
        public void Configure(EntityTypeBuilder<DishCategory> builder)
        {
            builder.HasKey(dc => new { dc.CategoryId, dc.DishId });
            builder.Ignore(dc => dc.Id);
        }
    }
}
