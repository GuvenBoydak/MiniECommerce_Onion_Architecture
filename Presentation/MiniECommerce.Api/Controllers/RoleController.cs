using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MiniECommerce.Application;

namespace MiniECommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RolesController : CustomBaseController
    {
        private readonly IMediator _mediator;

        public RolesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            List<RoleListDto> result = await _mediator.Send(new GetAllRoleQuery());

            return CreateActionResult(CustomResponseDto<List<RoleListDto>>.Success(200, result, "Listing All Roles"));
        }

        [HttpGet]
        [Route("getActive")]
        public async Task<IActionResult> GetActiveAsync()
        {
            List<RoleListDto> result = await _mediator.Send(new GetActiveRoleQuery());

            return CreateActionResult(CustomResponseDto<List<RoleListDto>>.Success(200, result, "Listing Active Roles"));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetByIDAsync([FromRoute] GetByIDRoleQuery request)
        {
            RoleDto result = await _mediator.Send(request);

            return CreateActionResult(CustomResponseDto<RoleDto>.Success(200, result, "Listing Role"));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromRoute] CreateRoleCommand request)
        {
            await _mediator.Send(request);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204, "Create Successfully"));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromRoute] UpdateRoleCommand request)
        {
            await _mediator.Send(request);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204, "Update Successfully"));
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] DeleteRoleCommand request)
        {
            await _mediator.Send(request);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204, "Delete Successfully"));
        }
    }
}
