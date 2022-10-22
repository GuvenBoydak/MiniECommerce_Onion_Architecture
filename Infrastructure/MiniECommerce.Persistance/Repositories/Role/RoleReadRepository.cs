using Microsoft.EntityFrameworkCore;
using MiniECommerce.Application;
using MiniECommerce.Domain;

namespace MiniECommerce.Persistance
{
    public class RoleReadRepository : ReadRepository<Role>, IReadRoleRepository
    {
        public async Task<List<Role>> GetRoles(Guid id)
        {
            return await Table.Where(x => x.ID == id).ToListAsync();
        }
    }
}
