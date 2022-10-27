using MediatR;

namespace MiniECommerce.Application
{
    public class DeleteAppUserCommandHandler :AsyncRequestHandler<DeleteAppUserCommand>
    {
        private readonly IAppUserService _appUserService;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteAppUserCommandHandler(IAppUserService appUserService, IUnitOfWork unitOfWork)
        {
            _appUserService = appUserService;
            _unitOfWork = unitOfWork;
        }

        protected override async Task Handle(DeleteAppUserCommand request, CancellationToken cancellationToken)
        {
            await _appUserService.DeleteAsync(request.ID);
            await _unitOfWork.SaveAsync();
        }
    }
}
