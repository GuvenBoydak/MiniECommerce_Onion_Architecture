using AutoMapper;
using MediatR;
using MiniECommerce.Domain;

namespace MiniECommerce.Application
{
    public class GetByIDRoleQueryHandler : IRequestHandler<GetByIDRoleQuery, RoleDto>
    {
        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;

        public GetByIDRoleQueryHandler(IRoleService roleService, IMapper mapper)
        {
            _roleService = roleService;
            _mapper = mapper;
        }

        public async Task<RoleDto> Handle(GetByIDRoleQuery request, CancellationToken cancellationToken)
        {
           Role role = await _roleService.GetByIDAsync(request.ID);

            RoleDto roleDto = _mapper.Map<Role, RoleDto>(role);

            return roleDto;
        }
    }
}
