using AutoMapper;
using MediatR;
using MiniECommerce.Domain;

namespace MiniECommerce.Application
{
    public class GetByIDOfferQueryHandler : IRequestHandler<GetByIDOfferQuery, OfferDto>
    {
        private readonly IOfferService _offerService;
        private readonly IMapper _mapper;

        public GetByIDOfferQueryHandler(IOfferService offerService, IMapper mapper)
        {
            _offerService = offerService;
            _mapper = mapper;
        }

        public async Task<OfferDto> Handle(GetByIDOfferQuery request, CancellationToken cancellationToken)
        {
            Offer offer = await _offerService.GetByIDAsync(request.ID);

            OfferDto offerDto = _mapper.Map<Offer, OfferDto>(offer);

            return offerDto;
        }
    }
}
