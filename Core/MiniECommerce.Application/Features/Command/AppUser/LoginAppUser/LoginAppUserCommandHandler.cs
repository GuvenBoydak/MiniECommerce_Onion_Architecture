using AutoMapper;
using MediatR;
using MiniECommerce.Domain;

namespace MiniECommerce.Application
{
    public class LoginAppUserCommandHandler : IRequestHandler<LoginAppUserCommand, AccessToken>
    {
        private readonly IAppUserService _appUserService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public LoginAppUserCommandHandler(IMapper mapper, IAppUserService appUserService, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _appUserService = appUserService;
            _unitOfWork = unitOfWork;
        }
        public async Task<AccessToken> Handle(LoginAppUserCommand request, CancellationToken cancellationToken)
        {
            AppUserLoginDto appUserLoginDto = _mapper.Map<LoginAppUserCommand, AppUserLoginDto>(request);

            AppUser appUser =  await _appUserService.LoginAsync(appUserLoginDto);

            AccessToken accessToken = await _appUserService.CreateAccessTokenAsync(appUser);

            await _unitOfWork.SaveAsync();

            return accessToken;
        }
    }
}
