using MediatR;

namespace MiniECommerce.Application
{
    public class GetByAppUserMadeOffersQuery:IRequest<List<OfferListDto>>
    {
        public Guid AppUserID { get; set; }
    }
}
