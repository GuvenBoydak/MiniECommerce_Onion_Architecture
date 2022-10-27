using AutoMapper;
using MediatR;
using MiniECommerce.Domain;

namespace MiniECommerce.Application
{
    public class UpdateOfferCommandHandler : AsyncRequestHandler<UpdateOfferCommand>
    {
        private readonly IOfferService _offerService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateOfferCommandHandler(IOfferService offerService, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _offerService = offerService;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        protected override async Task Handle(UpdateOfferCommand request, CancellationToken cancellationToken)
        {
            Offer offer = _mapper.Map<UpdateOfferCommand, Offer>(request);

            await _offerService.UpdateAsync(offer);

            await _unitOfWork.SaveAsync();
        }
    }
}
