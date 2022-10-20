using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MiniECommerce.Domain;

namespace MiniECommerce.Persistance
{
    public class BaseConfiguration : IEntityTypeConfiguration<BaseEntity>
    {
        public void Configure(EntityTypeBuilder<BaseEntity> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.CreatedDate).IsRequired();
            builder.Property(x => x.Status).IsRequired();
        }
    }
}
