using AutoMapper;
using MediatR;
using MiniECommerce.Domain;

namespace MiniECommerce.Application
{
    public class GetAllOfferQueryHandler : IRequestHandler<GetAllOfferQuery, List<OfferListDto>>
    {
        private readonly IOfferService _offerService;
        private readonly IMapper _mapper;

        public GetAllOfferQueryHandler(IOfferService offerService, IMapper mapper)
        {
            _offerService = offerService;
            _mapper = mapper;
        }

        public async Task<List<OfferListDto>> Handle(GetAllOfferQuery request, CancellationToken cancellationToken)
        {
            List<Offer> offers = await _offerService.GetActiveAsync();

            List<OfferListDto> offerListDtos = _mapper.Map<List<Offer>, List<OfferListDto>>(offers);

            return offerListDtos;
        }
    }
}
