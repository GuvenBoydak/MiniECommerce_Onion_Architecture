using Microsoft.EntityFrameworkCore;
using MiniECommerce.Application;
using MiniECommerce.Domain;

namespace MiniECommerce.Persistance
{
    public class AppUserRoleReadRepository : ReadRepository<AppUserRole>, IReadAppUserRoleRepository
    {
        public AppUserRoleReadRepository(MiniECommerceDbContext db) : base(db)
        {
        }

        public async Task<List<AppUserRole>> GetAppUserID(Guid id)
        {
            return await Table.Where(x => x.AppUserID == id).ToListAsync();
        }
    }
}
