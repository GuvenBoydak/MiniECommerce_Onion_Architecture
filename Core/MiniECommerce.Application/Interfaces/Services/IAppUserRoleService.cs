using MiniECommerce.Domain;

namespace MiniECommerce.Application
{
    public interface IAppUserRoleService : IBaseService<AppUserRole>
    {
        Task<List<AppUserRole>> GetAppUserID(Guid id);
    }
}
