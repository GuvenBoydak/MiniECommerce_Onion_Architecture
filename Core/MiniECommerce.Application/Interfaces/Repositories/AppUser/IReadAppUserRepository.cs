using MiniECommerce.Domain;

namespace MiniECommerce.Application
{
    public interface IReadAppUserRepository:IReadRepository<AppUser>
    {
        Task<AppUser> GetByEmailAsync(string email);

        Task<AppUser> GetByActivationCode(Guid code);
    }
}
