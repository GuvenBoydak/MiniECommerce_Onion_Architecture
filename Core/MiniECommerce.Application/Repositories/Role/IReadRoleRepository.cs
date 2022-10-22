using MiniECommerce.Domain;

namespace MiniECommerce.Application
{
    public interface IReadRoleRepository:IReadRepository<Role>
    {
        Task<List<Role>> GetRoles(Guid id);
    }
}
