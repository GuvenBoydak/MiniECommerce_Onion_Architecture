using AutoMapper;
using MediatR;
using MiniECommerce.Domain;

namespace MiniECommerce.Application
{
    public class GetAllAppUserRoleQueryHandler : IRequestHandler<GetAllAppUserRoleQuery, List<AppUserRoleListDto>>
    {
        private readonly IAppUserRoleService _appUserRoleService;
        private readonly IMapper _mapper;

        public GetAllAppUserRoleQueryHandler(IMapper mapper, IAppUserRoleService appUserRoleService)
        {
            _mapper = mapper;
            _appUserRoleService = appUserRoleService;
        }
        public async Task<List<AppUserRoleListDto>> Handle(GetAllAppUserRoleQuery request, CancellationToken cancellationToken)
        {
            List<AppUserRole> appUserRoles = await _appUserRoleService.GetAll();

            List<AppUserRoleListDto> appUserRoleListDtos = _mapper.Map<List<AppUserRole>, List<AppUserRoleListDto>>(appUserRoles);

            return appUserRoleListDtos;
        }
    }
}
