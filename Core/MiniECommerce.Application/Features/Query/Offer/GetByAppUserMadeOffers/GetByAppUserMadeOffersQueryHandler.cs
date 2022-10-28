using AutoMapper;
using MediatR;
using MiniECommerce.Domain;

namespace MiniECommerce.Application
{
    public class GetByAppUserMadeOffersQueryHandler : IRequestHandler<GetByAppUserMadeOffersQuery, List<OfferListDto>>
    {
        private readonly IOfferService _offerService;
        private readonly IMapper _mapper;

        public GetByAppUserMadeOffersQueryHandler(IOfferService offerService, IMapper mapper)
        {
            _offerService = offerService;
            _mapper = mapper;
        }

        public async Task<List<OfferListDto>> Handle(GetByAppUserMadeOffersQuery request, CancellationToken cancellationToken)
        {
            List<Offer> offers = await _offerService.GetByAppUserMadeOffersAsync(request.AppUserID);

            List<OfferListDto> offerListDtos = _mapper.Map<List<Offer>, List<OfferListDto>>(offers);

            return offerListDtos;
        }
    }
}
