using AutoMapper;
using MediatR;
using MiniECommerce.Domain;

namespace MiniECommerce.Application
{
    public class CreateRoleCommandHandler : AsyncRequestHandler<CreateRoleCommand>
    {
        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateRoleCommandHandler(IRoleService roleService, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _roleService = roleService;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        protected override async Task Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            Role role = _mapper.Map<CreateRoleCommand, Role>(request);

            await _roleService.AddAsync(role);
            await _unitOfWork.SaveAsync();
        }
    }
}
