using IntelligentCooking.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IntelligentCooking.DAL.EntityConfigurations
{
    public class FavouriteConfiguration : IEntityTypeConfiguration<Favourite>
    {
        public void Configure(EntityTypeBuilder<Favourite> builder)
        {
            builder.HasKey(f => new { f.UserId, f.DishId });
            builder.Ignore(dc => dc.Id);
        }
    }
}
