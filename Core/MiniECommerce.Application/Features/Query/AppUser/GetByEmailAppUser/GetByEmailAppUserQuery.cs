using MediatR;

namespace MiniECommerce.Application
{
    public class GetByEmailAppUserQuery : IRequest<AppUserDto>
    {
        public string Email { get; set; }
    }
}
