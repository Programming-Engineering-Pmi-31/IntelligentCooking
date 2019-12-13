using IntelligentCooking.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IntelligentCooking.DAL.EntityConfigurations
{
    public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
    {
        public void Configure(EntityTypeBuilder<RefreshToken> builder)
        {
            builder.HasKey(t => t.Token);
            builder.Property(t => t.Token)
                .ValueGeneratedNever();

            builder.Ignore(c => c.Id);
            builder.Property(t => t.JwtId)
                .IsRequired();
        }
    }
}
