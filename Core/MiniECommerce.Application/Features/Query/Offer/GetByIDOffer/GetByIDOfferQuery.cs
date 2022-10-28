using MediatR;

namespace MiniECommerce.Application
{
    public class GetByIDOfferQuery:IRequest<OfferDto>
    {
        public Guid ID { get; set; }
    }
}
