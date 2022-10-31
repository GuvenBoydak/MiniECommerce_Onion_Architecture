using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MiniECommerce.Application;
using MiniECommerce.Domain;

namespace MiniECommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUsersController : CustomBaseController
    {
        private readonly IMediator _mediator;

        public AppUsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize]
        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            List<AppUserListDto> result = await _mediator.Send(new GetAllAppUserQuery());

            return CreateActionResult(CustomResponseDto<List<AppUserListDto>>.Success(200,result, "Listing All AppUsers"));
        }

        [Authorize]
        [HttpGet]
        [Route("GetActive")]
        public async Task<IActionResult> GetActiveAsync()
        {
            List<AppUserListDto> result = await _mediator.Send(new GetActiveAppUserQuery());

            return CreateActionResult(CustomResponseDto<List<AppUserListDto>>.Success(200,result, "Listing Active AppUsers"));
        }

        [Authorize]
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetByIDAsync([FromRoute] GetByIDAppUserQuery request )
        {
            AppUserDto result = await _mediator.Send(request);

            return CreateActionResult(CustomResponseDto<AppUserDto>.Success(200,result, "Listing AppUser"));
        }

        [Authorize]
        [HttpGet]
        [Route("{id}/email")]
        public async Task<IActionResult> GetByEmailAsync([FromRoute] GetByEmailAppUserQuery request)
        {
            AppUserDto result = await _mediator.Send(request);

            return CreateActionResult(CustomResponseDto<AppUserDto>.Success(200, result, "Listing AppUser"));
        }

        [Authorize]
        [HttpGet]
        [Route("{id}/activation-code")]
        public async Task<IActionResult> GetByActivationCodeAsync([FromRoute] GetByActivationCodeQuery request)
        {
            AppUserDto result = await _mediator.Send(request);

            if (result.Active == true)
                return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204, "Activation Successfully"));
            else if (result.IsLock == false)
                return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204, "Access Restriction Removed for Your Account"));

            return CreateActionResult(CustomResponseDto<NoContentDto>.Fail(404, "Activation error"));
        }

        
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterAppUserCommand request)
        {
            await _mediator.Send(request);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Fail(204, "Register Successfully"));
        }

        
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginAppUserCommand request)
        {
            AccessToken result= await _mediator.Send(request);

            return CreateActionResult(CustomResponseDto<AccessToken>.Fail(200,result.Token, "login Successfully token listing"));
        }

        [Authorize]
        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateAppUserCommand request)
        {
            await _mediator.Send(request);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Fail(204, "Updated Successfully"));
        }

        [Authorize]
        [HttpPut]
        [Route("change-password")]
        public async Task<IActionResult> ChangePasswordAsync([FromBody] UpdatePasswordAppUserCommand request)
        {

            if (!CheckPassword.CheckingPassword(request.NewPassword, request.ConfirmPassword))
                return CreateActionResult(CustomResponseDto<NoContentDto>.Fail(400, "The password entered doesn't match"));

            await _mediator.Send(request);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Fail(204, "Change Password Successfully"));
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] DeleteAppUserCommand request)
        {
            await _mediator.Send(request);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Fail(204, "Deleted Successfully"));
        }
    }
}
