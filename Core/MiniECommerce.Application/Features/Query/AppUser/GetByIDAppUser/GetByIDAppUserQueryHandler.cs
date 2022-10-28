using AutoMapper;
using MediatR;
using MiniECommerce.Domain;

namespace MiniECommerce.Application
{
    public class GetByIDAppUserQueryHandler : IRequestHandler<GetByIDAppUserQuery, AppUserDto>
    {
        private readonly IAppUserService _appUserService;
        private readonly IMapper _mapper;

        public GetByIDAppUserQueryHandler(IAppUserService appUserService, IMapper mapper)
        {
            _appUserService = appUserService;
            _mapper = mapper;
        }
        public async Task<AppUserDto> Handle(GetByIDAppUserQuery request, CancellationToken cancellationToken)
        {
            AppUser appUser = await _appUserService.GetByIDAsync(request.ID);

            AppUserDto appUserDto = _mapper.Map<AppUser, AppUserDto>(appUser);

            return appUserDto;
        }
    }
}
