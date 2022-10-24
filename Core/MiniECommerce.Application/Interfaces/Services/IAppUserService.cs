using MiniECommerce.Domain;

namespace MiniECommerce.Application
{
    public interface IAppUserService : IBaseService<AppUser>
    {
        Task<AppUser> GetByEmailAsync(string email);

        Task<AppUser> GetByActivationCode(Guid code);
    }
}
