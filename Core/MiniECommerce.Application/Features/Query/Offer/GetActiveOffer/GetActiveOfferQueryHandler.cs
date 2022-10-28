using AutoMapper;
using MediatR;
using MiniECommerce.Domain;

namespace MiniECommerce.Application
{
    public class GetActiveOfferQueryHandler : IRequestHandler<GetActiveOfferQuery, List<OfferListDto>>
    {
        private readonly IOfferService _offerService;
        private readonly IMapper _mapper;

        public GetActiveOfferQueryHandler(IOfferService offerService, IMapper mapper)
        {
            _offerService = offerService;
            _mapper = mapper;
        }

        public async Task<List<OfferListDto>> Handle(GetActiveOfferQuery request, CancellationToken cancellationToken)
        {
            List<Offer> offers = await _offerService.GetActiveAsync();

            List<OfferListDto> offerListDtos = _mapper.Map<List<Offer>, List<OfferListDto>>(offers);

            return offerListDtos;
        }
    }
}
