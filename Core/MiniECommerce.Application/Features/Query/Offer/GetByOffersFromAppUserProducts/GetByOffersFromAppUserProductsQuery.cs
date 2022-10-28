using MediatR;

namespace MiniECommerce.Application
{
    public class GetByOffersFromAppUserProductsQuery:IRequest<List<OfferListDto>>
    {
        public Guid AppUserID { get; set; }
    }
}
