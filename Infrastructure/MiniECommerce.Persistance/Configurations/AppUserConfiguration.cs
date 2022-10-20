using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MiniECommerce.Domain;

namespace MiniECommerce.Persistance
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(x => x.UserName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.ActivationCode).IsRequired();
            builder.Property(x => x.Active).IsRequired().HasMaxLength(50);
            builder.Property(x => x.LastActivty).IsRequired().HasMaxLength(50);
        }
    }
}
