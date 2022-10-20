using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MiniECommerce.Persistance
{
    internal class DesignTimeDBContextFactory : IDesignTimeDbContextFactory<MiniECommerceDbContext>
    {
        public MiniECommerceDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<MiniECommerceDbContext> dbContextOptionsBuilder = new();
            dbContextOptionsBuilder.UseNpgsql(Configuration.ConnectionString);
            return new MiniECommerceDbContext(dbContextOptionsBuilder.Options);

        }
    }
}
