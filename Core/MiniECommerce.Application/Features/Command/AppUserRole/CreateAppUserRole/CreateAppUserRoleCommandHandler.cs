using AutoMapper;
using MediatR;
using MiniECommerce.Domain;

namespace MiniECommerce.Application
{
    public class CreateAppUserRoleCommandHandler : AsyncRequestHandler<CreateAppUserRoleCommand>
    {
        private readonly IAppUserRoleService _appUserRoleService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateAppUserRoleCommandHandler(IAppUserRoleService appUserRoleService, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _appUserRoleService = appUserRoleService;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        protected override async Task Handle(CreateAppUserRoleCommand request, CancellationToken cancellationToken)
        {
            AppUserRole appUserRole = _mapper.Map<CreateAppUserRoleCommand, AppUserRole>(request);

            await _appUserRoleService.AddAsync(appUserRole);

            await _unitOfWork.SaveAsync();
        }
    }

}
