using MiniECommerce.Domain;

namespace MiniECommerce.Application
{
    public interface IAppUserRoleService : IBaseService<AppUserRole>
    {
        Task<CustomResponseDto<List<AppUserRole>>> GetAppUserID(Guid id);
    }
}
