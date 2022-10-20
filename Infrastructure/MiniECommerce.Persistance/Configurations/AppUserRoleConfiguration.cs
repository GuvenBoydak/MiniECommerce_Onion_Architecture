using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MiniECommerce.Domain;

namespace MiniECommerce.Persistance
{
    public class AppUserRoleConfiguration : IEntityTypeConfiguration<AppUserRole>
    {
        public void Configure(EntityTypeBuilder<AppUserRole> builder)
        {
            builder.Property(x => x.ID).IsRequired();
            builder.HasKey(x => new { x.RoleID, x.AppUserID });
        }
    }
}
