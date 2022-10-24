using Microsoft.EntityFrameworkCore;
using MiniECommerce.Application;
using MiniECommerce.Domain;

namespace MiniECommerce.Persistance
{
    public class RoleReadRepository : ReadRepository<Role>, IReadRoleRepository
    {
    }
}
