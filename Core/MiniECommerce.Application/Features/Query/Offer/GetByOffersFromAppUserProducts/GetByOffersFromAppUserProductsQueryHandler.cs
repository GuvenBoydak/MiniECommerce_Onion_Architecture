using AutoMapper;
using MediatR;
using MiniECommerce.Domain;

namespace MiniECommerce.Application
{
    public class GetByOffersFromAppUserProductsQueryHandler : IRequestHandler<GetByOffersFromAppUserProductsQuery, List<OfferListDto>>
    {
        private readonly IOfferService _offerService;
        private readonly IMapper _mapper;

        public GetByOffersFromAppUserProductsQueryHandler(IOfferService offerService, IMapper mapper)
        {
            _offerService = offerService;
            _mapper = mapper;
        }

        public async Task<List<OfferListDto>> Handle(GetByOffersFromAppUserProductsQuery request, CancellationToken cancellationToken)
        {
            List<Offer> offers = await _offerService.GetByOffersFromAppUserProductsAsync(request.AppUserID);

            List<OfferListDto> offerListDtos = _mapper.Map<List<Offer>, List<OfferListDto>>(offers);

            return offerListDtos;
        }
    }
}
