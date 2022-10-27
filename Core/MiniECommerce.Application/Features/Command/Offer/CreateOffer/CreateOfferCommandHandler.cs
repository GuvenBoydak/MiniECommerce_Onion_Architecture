using AutoMapper;
using MediatR;
using MiniECommerce.Domain;

namespace MiniECommerce.Application
{
    public class CreateOfferCommandHandler : AsyncRequestHandler<CreateOfferCommand>
    {
        private readonly IOfferService _offerService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateOfferCommandHandler(IOfferService offerService, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _offerService = offerService;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        protected override async Task Handle(CreateOfferCommand request, CancellationToken cancellationToken)
        {
            Offer offer = _mapper.Map<CreateOfferCommand, Offer>(request);

            await _offerService.AddAsync(offer);

            await _unitOfWork.SaveAsync();
        }
    }
}
