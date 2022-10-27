using MediatR;

namespace MiniECommerce.Application
{
    public class DeleteProductCommandHandler : AsyncRequestHandler<DeleteProductCommand>
    {
        private readonly IProductService _productService;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteProductCommandHandler(IProductService productService, IUnitOfWork unitOfWork)
        {
            _productService = productService;
            _unitOfWork = unitOfWork;
        }

        protected override async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            await _productService.DeleteAsync(request.ID);

            await _unitOfWork.SaveAsync();
        }
    }

}
