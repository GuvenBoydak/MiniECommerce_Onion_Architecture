using AutoMapper;
using MediatR;
using MiniECommerce.Domain;

namespace MiniECommerce.Application
{
    public class GetByOffersOnTheProductQueryHandler : IRequestHandler<GetByOffersOnTheProductQuery, List<OfferListDto>>
    {
        private readonly IOfferService _offerService;
        private readonly IMapper _mapper;

        public GetByOffersOnTheProductQueryHandler(IOfferService offerService, IMapper mapper)
        {
            _offerService = offerService;
            _mapper = mapper;
        }

        public async Task<List<OfferListDto>> Handle(GetByOffersOnTheProductQuery request, CancellationToken cancellationToken)
        {
            List<Offer> offers = await _offerService.GetByOffersOnTheProductAsync(request.ProductID);

            List<OfferListDto> offerListDtos = _mapper.Map<List<Offer>, List<OfferListDto>>(offers);

            return offerListDtos;
        }
    }
}
