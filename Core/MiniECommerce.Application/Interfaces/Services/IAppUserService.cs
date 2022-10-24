using MiniECommerce.Domain;

namespace MiniECommerce.Application
{
    public interface IAppUserService : IBaseService<AppUser>
    {
        Task<CustomResponseDto<AppUser>> GetByEmailAsync(string email);

        Task<CustomResponseDto<AppUser>> GetByActivationCode(Guid code);

        Task<CustomResponseDto<AppUser>> RegisterAsync(AppUser registerDto);

        Task<CustomResponseDto<AppUser>> LoginAsync(string email,string password);

        Task<CustomResponseDto<AccessToken>> CreateAccessToken(AppUser entity);

        Task<CustomResponseDto<NoContentDto>> UpdatePasswordAsync(AppUser entity);
    }
}
