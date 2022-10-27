using AutoMapper;
using MediatR;

namespace MiniECommerce.Application
{
    public class UpdatePasswordAppUserCommandHandler : AsyncRequestHandler<UpdatePasswordAppUserCommand>
    {
        private readonly IAppUserService _appUserService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UpdatePasswordAppUserCommandHandler(IAppUserService appUserService, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _appUserService = appUserService;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        protected override async Task Handle(UpdatePasswordAppUserCommand request, CancellationToken cancellationToken)
        {
            AppUserPasswordUpdateDto appUserPasswordUpdateDto = _mapper.Map<UpdatePasswordAppUserCommand, AppUserPasswordUpdateDto>(request);

            await _appUserService.UpdatePasswordAsync(appUserPasswordUpdateDto);
            await _unitOfWork.SaveAsync();
        }
    }
}
