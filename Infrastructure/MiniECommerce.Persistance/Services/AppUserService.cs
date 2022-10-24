using MiniECommerce.Application;
using MiniECommerce.Domain;

namespace MiniECommerce.Persistance.Services
{
    public class AppUserService : BaseService<AppUser>, IAppUserService
    {
        public AppUserService(IReadRepository<AppUser> readRepository, IWriteRepository<AppUser> writeRepository, IUnitOfWork unitOfWork) : base(readRepository, writeRepository, unitOfWork)
        {
        }

        public async Task<AppUser> GetByActivationCode(Guid code)
        {
            return await _readRepository.GetByFirstAsync(x => x.ActivationCode == code);
        }

        public async Task<AppUser> GetByEmailAsync(string email)
        {
            return await _readRepository.GetByFirstAsync(x=>x.Email==email);
        }
    }
}
