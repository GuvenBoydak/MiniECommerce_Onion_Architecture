using MediatR;

namespace MiniECommerce.Application
{
    public class GetByOffersOnTheProductQuery:IRequest<List<OfferListDto>>
    {
        public Guid ProductID { get; set; }
    }
}
