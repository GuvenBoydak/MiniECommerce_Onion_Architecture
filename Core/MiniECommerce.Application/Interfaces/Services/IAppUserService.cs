using MiniECommerce.Domain;

namespace MiniECommerce.Application
{
    public interface IAppUserService : IBaseService<AppUser>
    {
        Task<AppUser> GetByEmailAsync(string email);

        Task<AppUser> GetByActivationCodeAsync(Guid code);

        Task<AppUser> RegisterAsync(AppUserRegisterDto registerDto);

        Task<AppUser> LoginAsync(AppUserLoginDto entity);

        Task<AccessToken> CreateAccessTokenAsync(AppUser entity);

        Task UpdatePasswordAsync(Guid id, AppUserPasswordUpdateDto entity);
    }
}
