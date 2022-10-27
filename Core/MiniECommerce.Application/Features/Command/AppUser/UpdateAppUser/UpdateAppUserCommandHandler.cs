using AutoMapper;
using MediatR;
using MiniECommerce.Domain;

namespace MiniECommerce.Application
{
    public class UpdateAppUserCommandHandler : AsyncRequestHandler<UpdateAppUserCommand>
    {
        private readonly IAppUserService _appUserService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateAppUserCommandHandler(IAppUserService appUserService, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _appUserService = appUserService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        protected override async Task Handle(UpdateAppUserCommand request, CancellationToken cancellationToken)
        {
           AppUser appUser = _mapper.Map<UpdateAppUserCommand, AppUser>(request);

            await _appUserService.UpdateAsync(appUser);
            await _unitOfWork.SaveAsync();
        }
    }
}
