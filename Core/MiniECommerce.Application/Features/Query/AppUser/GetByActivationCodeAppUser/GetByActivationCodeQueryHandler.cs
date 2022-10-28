using AutoMapper;
using MediatR;
using MiniECommerce.Domain;

namespace MiniECommerce.Application
{
    public class GetByActivationCodeQueryHandler : IRequestHandler<GetByActivationCodeQuery,AppUserDto>
    {
        private readonly IAppUserService _appUserService;
        private readonly IMapper _mapper;

        public GetByActivationCodeQueryHandler(IAppUserService appUserService, IMapper mapper)
        {
            _appUserService = appUserService;
            _mapper = mapper;
        }
        public async Task<AppUserDto> Handle(GetByActivationCodeQuery request, CancellationToken cancellationToken)
        {
            AppUser appUser = await _appUserService.GetByActivationCodeAsync(request.Code);

            AppUserDto appUserDto = _mapper.Map<AppUser,AppUserDto>(appUser);

            return appUserDto;
        }
    }
}
