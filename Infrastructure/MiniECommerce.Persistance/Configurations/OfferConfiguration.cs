using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MiniECommerce.Domain;

namespace MiniECommerce.Persistance
{
    public class OfferConfiguration : IEntityTypeConfiguration<Offer>
    {
        public void Configure(EntityTypeBuilder<Offer> builder)
        {
            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.ProductID).IsRequired();
            builder.Property(x => x.AppUserID).IsRequired();
        }
    }
}
