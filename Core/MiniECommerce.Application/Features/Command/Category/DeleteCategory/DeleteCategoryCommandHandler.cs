using MediatR;

namespace MiniECommerce.Application
{
    public class DeleteCategoryCommandHandler : AsyncRequestHandler<DeleteCategoryCommand>
    {
        private readonly ICategoryService _categoryService;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCategoryCommandHandler(ICategoryService categoryService, IUnitOfWork unitOfWork)
        {
            _categoryService = categoryService;
            _unitOfWork = unitOfWork;
        }

        protected override async Task Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            await _categoryService.DeleteAsync(request.ID);
            await _unitOfWork.SaveAsync();
        }
    }
}
