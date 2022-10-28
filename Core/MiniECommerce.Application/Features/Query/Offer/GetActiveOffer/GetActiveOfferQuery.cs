using MediatR;

namespace MiniECommerce.Application
{
    public class GetActiveOfferQuery:IRequest<List<OfferListDto>>
    {
    }
}
