using AutoMapper;
using MediatR;
using MiniECommerce.Domain;

namespace MiniECommerce.Application
{
    public class UpdateBrandCommandHandler : AsyncRequestHandler<UpdateAppUserCommand>
    {
        private readonly IBrandService _brandService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateBrandCommandHandler(IBrandService brandService, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _brandService = brandService;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        protected override async Task Handle(UpdateAppUserCommand request, CancellationToken cancellationToken)
        {
            Brand brand = _mapper.Map<UpdateAppUserCommand, Brand>(request);

            await _brandService.UpdateAsync(brand);
            await _unitOfWork.SaveAsync();
        }
    }
}
