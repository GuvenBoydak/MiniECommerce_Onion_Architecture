using MiniECommerce.Domain;

namespace MiniECommerce.Application
{
    public interface IReadAppUserRepository:IWriteRepository<AppUser>
    {
        Task<AppUser> GetByEmailAsync(string email);

        Task<AppUser> GetByActivationCode(Guid code);

        Task<List<Product>> GetAppUserProductsAsync(int id);

        Task<List<Role>> GetRoles(AppUser appUser);

        Task<List<Offer>> GetByAppUserOffersAsync(Guid id);

        Task<List<Product>> GetByAppUserProductsOffers(Guid id);
    }
}
