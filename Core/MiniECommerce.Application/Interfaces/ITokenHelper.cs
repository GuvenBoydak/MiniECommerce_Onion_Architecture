using MiniECommerce.Domain;

namespace MiniECommerce.Application
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(AppUser appUser, List<Role> roles);
    }
}
