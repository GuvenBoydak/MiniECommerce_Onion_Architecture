using MiniECommerce.Application;
using MiniECommerce.Domain;

namespace MiniECommerce.Persistance
{
    public class RoleWriteRepository : WriteRepository<Role>, IWriteRoleRepository
    {
        public RoleWriteRepository(MiniECommerceDbContext db) : base(db)
        {
        }
    }
}
