using MiniECommerce.Application;
using MiniECommerce.Domain;

namespace MiniECommerce.Persistance
{
    public class RoleWriterepository : WriteRepository<Role>, IWriteRoleRepository
    {
        public RoleWriterepository(MiniECommerceDbContext db) : base(db)
        {
        }
    }
}
