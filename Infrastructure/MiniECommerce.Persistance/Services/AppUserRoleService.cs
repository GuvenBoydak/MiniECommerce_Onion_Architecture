using Microsoft.EntityFrameworkCore;
using MiniECommerce.Application;
using MiniECommerce.Domain;

namespace MiniECommerce.Persistance
{
    public class AppUserRoleService : BaseService<AppUserRole>, IAppUserRoleService
    {
        public AppUserRoleService(IReadRepository<AppUserRole> readRepository, IWriteRepository<AppUserRole> writeRepository, IUnitOfWork unitOfWork) : base(readRepository, writeRepository)
        {
        }

        public async Task<List<AppUserRole>> GetAppUserID(Guid id)
        {
            return await _readRepository.Where(x=>x.AppUserID==id).ToListAsync();
        }
    }
}
