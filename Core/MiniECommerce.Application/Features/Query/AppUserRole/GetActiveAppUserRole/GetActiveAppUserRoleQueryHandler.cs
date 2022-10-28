using AutoMapper;
using MediatR;
using MiniECommerce.Domain;

namespace MiniECommerce.Application
{
    public class GetActiveAppUserRoleQueryHandler : IRequestHandler<GetActiveAppUserRoleQuery, List<AppUserRoleListDto>>
    {
        private readonly IAppUserRoleService _appUserRoleService;
        private readonly IMapper _mapper;

        public GetActiveAppUserRoleQueryHandler( IMapper mapper, IAppUserRoleService appUserRoleService)
        {
            _mapper = mapper;
            _appUserRoleService = appUserRoleService;
        }
        public async Task<List<AppUserRoleListDto>> Handle(GetActiveAppUserRoleQuery request, CancellationToken cancellationToken)
        {
            List<AppUserRole> appUserRoles = await _appUserRoleService.GetActiveAsync();

            List<AppUserRoleListDto> appUserRoleListDtos = _mapper.Map<List<AppUserRole>, List<AppUserRoleListDto>>(appUserRoles);

            return appUserRoleListDtos;
        }
    }
}
