using AutoMapper;
using MediatR;
using MiniECommerce.Domain;

namespace MiniECommerce.Application
{
    public class GetAppUserIDAppUserRoleQueryHandler : IRequestHandler<GetAppUserIDAppUserRoleQuery, List<AppUserRoleListDto>>
    {
        private readonly IAppUserRoleService _appUserRoleService;
        private readonly IMapper _mapper;

        public GetAppUserIDAppUserRoleQueryHandler(IMapper mapper, IAppUserRoleService appUserRoleService)
        {
            _mapper = mapper;
            _appUserRoleService = appUserRoleService;
        }
        public async Task<List<AppUserRoleListDto>> Handle(GetAppUserIDAppUserRoleQuery request, CancellationToken cancellationToken)
        {
            List<AppUserRole> appUserRoles = await _appUserRoleService.GetAppUserID(request.AppUserID);

            List<AppUserRoleListDto> appUserRoleListDtos = _mapper.Map<List<AppUserRole>, List<AppUserRoleListDto>>(appUserRoles);

            return appUserRoleListDtos;
        }
    }
}
