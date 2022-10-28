using MediatR;

namespace MiniECommerce.Application
{
    public class GetByActivationCodeQuery:IRequest<AppUserDto>
    {
        public Guid Code { get; set; }
    }
}
