using MediatR;

namespace MiniECommerce.Application
{
    public class GetByIDAppUserQuery:IRequest<AppUserDto>
    {
        public Guid ID { get; set; }
    }
}
