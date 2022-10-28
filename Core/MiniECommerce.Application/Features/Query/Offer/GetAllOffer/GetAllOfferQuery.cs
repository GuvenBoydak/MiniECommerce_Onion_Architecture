using MediatR;

namespace MiniECommerce.Application
{
    public class GetAllOfferQuery:IRequest<List<OfferListDto>>
    {
    }
}
