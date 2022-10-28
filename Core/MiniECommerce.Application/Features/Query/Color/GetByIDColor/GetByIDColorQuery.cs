using MediatR;

namespace MiniECommerce.Application
{
    public class GetByIDColorQuery:IRequest<ColorDto>
    {
        public Guid ID { get; set; }
    }
}
