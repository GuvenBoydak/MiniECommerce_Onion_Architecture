using Microsoft.EntityFrameworkCore;
using MiniECommerce.Application;
using MiniECommerce.Domain;

namespace MiniECommerce.Persistance
{
    public class AppUserReadRepository : ReadRepository<AppUser>, IReadAppUserRepository
    {
        public AppUserReadRepository(MiniECommerceDbContext db) : base(db)
        {
        }

        public async Task<AppUser> GetByActivationCode(Guid code)
        {
            return await Table.FirstOrDefaultAsync(x => x.ActivationCode == code);
        }

        public async Task<AppUser> GetByEmailAsync(string email)
        {
            return await Table.FirstOrDefaultAsync(x => x.Email == email);
        }
    }
}
