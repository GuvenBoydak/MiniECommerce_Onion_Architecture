using AutoMapper;
using MediatR;
using MiniECommerce.Domain;

namespace MiniECommerce.Application
{
    public class UpdateRoleCommandHandler : AsyncRequestHandler<UpdateRoleCommand>
    {
        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateRoleCommandHandler(IRoleService roleService, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _roleService = roleService;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        protected override async Task Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
        {
            Role role = _mapper.Map<UpdateRoleCommand, Role>(request);

            await _roleService.AddAsync(role);
            await _unitOfWork.SaveAsync();
        }
    }
}
