using MediatR;
using MiniECommerce.Domain;

namespace MiniECommerce.Application
{
    public class LoginAppUserCommand:IRequest<AccessToken>
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
