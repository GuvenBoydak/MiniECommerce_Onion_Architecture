using MiniECommerce.Application;
using MiniECommerce.Domain;

namespace MiniECommerce.Persistance
{
    public class AppUserWriteRepository : WriteRepository<AppUser>, IWriteAppUserRepository
    {
        public AppUserWriteRepository(MiniECommerceDbContext db) : base(db)
        {
        }
    }
}
