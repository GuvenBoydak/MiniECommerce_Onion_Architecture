using MiniECommerce.Application;
using MiniECommerce.Domain;

namespace MiniECommerce.Persistance
{
    public class RoleService : BaseService<Role>, IRoleService
    {
        public RoleService(IReadRepository<Role> readRepository, IWriteRepository<Role> writeRepository, IUnitOfWork unitOfWork) : base(readRepository, writeRepository, unitOfWork)
        {
        }
    }
}
