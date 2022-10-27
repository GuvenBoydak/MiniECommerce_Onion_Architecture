using MediatR;

namespace MiniECommerce.Application
{
    public class DeleteAppUserRoleCommandHandler : AsyncRequestHandler<DeleteAppUserRoleCommand>
    {
        private readonly IAppUserRoleService _appUserRoleService;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteAppUserRoleCommandHandler(IAppUserRoleService appUserRoleService, IUnitOfWork unitOfWork)
        {
            _appUserRoleService = appUserRoleService;
            _unitOfWork = unitOfWork;
        }

        protected override async Task Handle(DeleteAppUserRoleCommand request, CancellationToken cancellationToken)
        {
            await _appUserRoleService.DeleteAsync(request.ID);

            await _unitOfWork.SaveAsync();
        }
    }

}
