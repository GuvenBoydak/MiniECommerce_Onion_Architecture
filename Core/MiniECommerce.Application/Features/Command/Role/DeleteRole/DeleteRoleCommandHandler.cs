using MediatR;

namespace MiniECommerce.Application
{
    public class DeleteRoleCommandHandler : AsyncRequestHandler<DeleteRoleCommand>
    {
        private readonly IRoleService _roleService;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteRoleCommandHandler(IRoleService roleService, IUnitOfWork unitOfWork)
        {
            _roleService = roleService;
            _unitOfWork = unitOfWork;
        }

        protected override async Task Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            await _roleService.DeleteAsync(request.ID);
            await _unitOfWork.SaveAsync();
        }
    }
}
