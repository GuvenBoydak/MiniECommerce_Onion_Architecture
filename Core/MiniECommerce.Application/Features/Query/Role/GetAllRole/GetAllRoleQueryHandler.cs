using AutoMapper;
using MediatR;
using MiniECommerce.Domain;

namespace MiniECommerce.Application
{
    public class GetAllRoleQueryHandler : IRequestHandler<GetAllRoleQuery, List<RoleListDto>>
    {
        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;

        public GetAllRoleQueryHandler(IRoleService roleService, IMapper mapper)
        {
            _roleService = roleService;
            _mapper = mapper;
        }

        public async Task<List<RoleListDto>> Handle(GetAllRoleQuery request, CancellationToken cancellationToken)
        {
            List<Role> roles = await _roleService.GetActiveAsync();

            List<RoleListDto> roleListDtos = _mapper.Map<List<Role>, List<RoleListDto>>(roles);

            return roleListDtos;
        }
    }
}
