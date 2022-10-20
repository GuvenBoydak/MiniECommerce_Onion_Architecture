using Microsoft.EntityFrameworkCore;
using MiniECommerce.Domain;
using System.Reflection;

namespace MiniECommerce.Persistance
{
    public class MiniECommerceDbContext:DbContext
    {
        public MiniECommerceDbContext(DbContextOptions options):base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<AppUserRole> AppUserRoles { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Assembly'deki Tüm configuration dosylarını okuyor. IEntityTypeConfiguration'den implemente eden classları reflection sayesinde buluyor.
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
