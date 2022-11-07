using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MiniECommerce.Application;

namespace MiniECommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AppUserRolesController : CustomBaseController
    {
        private readonly IMediator _mediator;

        public AppUserRolesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            List<AppUserRoleListDto> result = await _mediator.Send(new GetAllAppUserRoleQuery());

            return CreateActionResult(CustomResponseDto<List<AppUserRoleListDto>>.Success(200, result, "Listing All AppUserRoles"));
        }

        [HttpGet]
        [Route("GetActive")]
        public async Task<IActionResult> GetActiveAsync()
        {
            List<AppUserRoleListDto> result = await _mediator.Send(new GetActiveAppUserRoleQuery());

            return CreateActionResult(CustomResponseDto<List<AppUserRoleListDto>>.Success(200, result, "Listing Active AppUserRoles"));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetByIDAsync([FromRoute] GetAppUserIDAppUserRoleQuery request)
        {
            List<AppUserRoleListDto> result = await _mediator.Send(request);

            return CreateActionResult(CustomResponseDto<List<AppUserRoleListDto>>.Success(200, result, "Listing AppUserRoles"));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateAppUserRoleCommand request)
        {
             await _mediator.Send(request);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204, "Create Successfully"));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateAppUserRoleCommand request)
        {
            await _mediator.Send(request);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204, "Update Successfully"));
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] DeleteAppUserCommand request)
        {
            await _mediator.Send(request);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204, "Delete Successfully"));
        }
    }
}
