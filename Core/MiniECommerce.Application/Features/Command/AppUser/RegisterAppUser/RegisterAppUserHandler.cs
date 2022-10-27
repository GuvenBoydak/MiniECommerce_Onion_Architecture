using AutoMapper;
using MediatR;

namespace MiniECommerce.Application
{
    public class RegisterAppUserHandler : AsyncRequestHandler<RegisterAppUserCommand>
    {
        private readonly IAppUserService _appUserService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public RegisterAppUserHandler(IMapper mapper, IAppUserService appUserService, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _appUserService = appUserService;
            _unitOfWork = unitOfWork;
        }

        protected override async Task Handle(RegisterAppUserCommand request, CancellationToken cancellationToken)
        {
            AppUserRegisterDto appUserResgiterDto = _mapper.Map<RegisterAppUserCommand, AppUserRegisterDto>(request);

            await _appUserService.RegisterAsync(appUserResgiterDto);
            await _unitOfWork.SaveAsync();
        }
    }
}
