using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MiniECommerce.Domain;

namespace MiniECommerce.Persistance
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.UnitPrice).IsRequired();
            builder.Property(x => x.ImageUrl).IsRequired();
            builder.Property(x => x.Description).IsRequired().HasMaxLength(500);
            builder.Property(x => x.IsOfferable).IsRequired();
            builder.Property(x => x.IsSold).IsRequired();
            builder.Property(x => x.UsageStatus).IsRequired();
            builder.Property(x => x.CategoryID).IsRequired();
            builder.Property(x => x.AppUserID).IsRequired();
        }
    }
}
