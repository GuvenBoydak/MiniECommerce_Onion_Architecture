using MiniECommerce.Application;
using MiniECommerce.Domain;

namespace MiniECommerce.Persistance
{
    public class AppUserRoleWriteRepositorty : WriteRepository<AppUserRole>, IWriteAppUserRoleRepository
    {
        public AppUserRoleWriteRepositorty(MiniECommerceDbContext db) : base(db)
        {
        }
    }
}
