using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using IntelligentCooking.Core.Entities;

namespace IntelligentCooking.DAL.EntityConfigurations
{
    public class LikeConfiguration: IEntityTypeConfiguration<Like>
    {
        public void Configure(EntityTypeBuilder<Like> builder)
        {
            builder.HasKey(l => new { l.UserId, l.DishId });
            builder.Ignore(l => l.Id);
        }
    }
}
