using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using IntelligentCooking.Core.Entities;

namespace IntelligentCooking.DAL.EntityConfigurations
{
    public class RatingConfiguration: IEntityTypeConfiguration<Rating>
    {
        public void Configure(EntityTypeBuilder<Rating> builder)
        {
            builder.HasKey(l => new { l.UserId, l.DishId });
            builder.Ignore(l => l.Id);
        }
    }
}
