using AutoMapper;
using MediatR;
using MiniECommerce.Domain;

namespace MiniECommerce.Application
{
    public class GetByEmailAppUserQueryHandler : IRequestHandler<GetByEmailAppUserQuery, AppUserDto>
    {
        private readonly IAppUserService _appUserService;
        private readonly IMapper _mapper;

        public GetByEmailAppUserQueryHandler(IAppUserService appUserService, IMapper mapper)
        {
            _appUserService = appUserService;
            _mapper = mapper;
        }
        public async Task<AppUserDto> Handle(GetByEmailAppUserQuery request, CancellationToken cancellationToken)
        {
            AppUser appUser = await _appUserService.GetByEmailAsync(request.Email);

            AppUserDto appUserDto = _mapper.Map<AppUser, AppUserDto>(appUser);

            return appUserDto;
        }
    }
}
