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
        private readonly IFireAndForgetJob _fireAndForgetJob;

        public LoginAppUserCommandHandler(IMapper mapper, IAppUserService appUserService, IUnitOfWork unitOfWork, IFireAndForgetJob fireAndForgetJob)
        {
            _mapper = mapper;
            _appUserService = appUserService;
            _unitOfWork = unitOfWork;
            _fireAndForgetJob = fireAndForgetJob;
        }
        public async Task<AccessToken> Handle(LoginAppUserCommand request, CancellationToken cancellationToken)
        {
            AppUserLoginDto appUserLoginDto = _mapper.Map<LoginAppUserCommand, AppUserLoginDto>(request);

            AppUser appUser =  await _appUserService.LoginAsync(appUserLoginDto);

            AccessToken accessToken = await _appUserService.CreateAccessTokenAsync(appUser);

            _fireAndForgetJob.SendMailJob(appUser);//Hangfire ile Hoşgeldin mesajı yolluyoruz.
            
            await _unitOfWork.SaveAsync();

            return accessToken;
        }
    }
}
