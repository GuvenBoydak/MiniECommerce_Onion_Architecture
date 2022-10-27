using AutoMapper;
using MediatR;
using MiniECommerce.Domain;

namespace MiniECommerce.Application
{
    public class UpdateProductCommandHandler : AsyncRequestHandler<UpdateProductCommand>
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateProductCommandHandler(IProductService productService, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _productService = productService;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        protected override async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            Product product = _mapper.Map<UpdateProductCommand, Product>(request);

            await _productService.UpdateAsync(product);

            await _unitOfWork.SaveAsync();
        }
    }

}
