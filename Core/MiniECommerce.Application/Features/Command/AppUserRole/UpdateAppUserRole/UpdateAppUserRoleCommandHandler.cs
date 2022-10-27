using AutoMapper;
using MediatR;
using MiniECommerce.Domain;

namespace MiniECommerce.Application
{
    public class UpdateAppUserRoleCommandHandler : AsyncRequestHandler<UpdateAppUserRoleCommand>
    {
        private readonly IAppUserRoleService _appUserRoleService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateAppUserRoleCommandHandler(IAppUserRoleService appUserRoleService, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _appUserRoleService = appUserRoleService;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        protected override async Task Handle(UpdateAppUserRoleCommand request, CancellationToken cancellationToken)
        {
            AppUserRole appUserRole = _mapper.Map<UpdateAppUserRoleCommand, AppUserRole>(request);

            await _appUserRoleService.UpdateAsync(appUserRole);

            await _unitOfWork.SaveAsync();
        }
    }
}
