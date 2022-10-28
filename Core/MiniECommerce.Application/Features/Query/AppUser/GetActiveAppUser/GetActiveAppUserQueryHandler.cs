using AutoMapper;
using MediatR;
using MiniECommerce.Domain;

namespace MiniECommerce.Application
{
    public class GetActiveAppUserQueryHandler : IRequestHandler<GetActiveAppUserQuery, List<AppUserListDto>>
    {
        private readonly IAppUserService _appUserService;
        private readonly IMapper _mapper;

        public GetActiveAppUserQueryHandler(IAppUserService appUserService, IMapper mapper)
        {
            _appUserService = appUserService;
            _mapper = mapper;
        }
        public async Task<List<AppUserListDto>> Handle(GetActiveAppUserQuery request, CancellationToken cancellationToken)
        {
            List<AppUser> appUsers = await _appUserService.GetActiveAsync();

            List<AppUserListDto> appUserListDtos = _mapper.Map<List<AppUser>, List<AppUserListDto>>(appUsers);

            return appUserListDtos;
        }
    }

}
