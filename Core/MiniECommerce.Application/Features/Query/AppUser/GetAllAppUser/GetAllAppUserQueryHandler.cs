using AutoMapper;
using MediatR;
using MiniECommerce.Domain;

namespace MiniECommerce.Application
{
    public class GetAllAppUserQueryHandler : IRequestHandler<GetAllAppUserQuery, List<AppUserListDto>>
    {
        private readonly IAppUserService _appUserService;
        private readonly IMapper _mapper;

        public GetAllAppUserQueryHandler(IAppUserService appUserService, IMapper mapper)
        {
            _appUserService = appUserService;
            _mapper = mapper;
        }
        public async Task<List<AppUserListDto>> Handle(GetAllAppUserQuery request, CancellationToken cancellationToken)
        {
            List<AppUser> appUsers = await _appUserService.GetAll();

            List<AppUserListDto> appUserListDtos = _mapper.Map<List<AppUser>, List<AppUserListDto>>(appUsers);

            return appUserListDtos;
        }
    }
}
