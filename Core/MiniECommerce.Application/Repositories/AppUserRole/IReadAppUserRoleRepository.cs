using MiniECommerce.Domain;

namespace MiniECommerce.Application
{
    public interface IReadAppUserRoleRepository:IReadRepository<AppUserRole>
    {
        Task<List<AppUserRole>> GetAppUserID(Guid id);
    }
}
