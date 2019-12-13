using IntelligentCooking.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IntelligentCooking.DAL.EntityConfigurations
{
    public class ImageConfiguration: IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder) 
        {
            builder.HasKey(i => new { i.DishId, i.Priority });
            builder.Ignore(i => i.Id);
        }
    }
}
