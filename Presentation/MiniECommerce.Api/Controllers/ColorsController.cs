using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiniECommerce.Application;

namespace MiniECommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ColorsController : CustomBaseController
    {
        private readonly IMediator _mediator;

        public ColorsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            List<ColorListDto> result = await _mediator.Send(new GetAllColorQuery());

            return CreateActionResult(CustomResponseDto<List<ColorListDto>>.Success(200, result, "Listing All Colors"));
        }

        [HttpGet]
        [Route("getActive")]
        public async Task<IActionResult> GetActiveAsync()
        {
            List<ColorListDto> result = await _mediator.Send(new GetActiveColorQuery());

            return CreateActionResult(CustomResponseDto<List<ColorListDto>>.Success(200, result, "Listing Active Colors"));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetByIDAsync([FromRoute] GetByIDColorQuery request)
        {
            ColorDto result = await _mediator.Send(request);

            return CreateActionResult(CustomResponseDto<ColorDto>.Success(200, result, "Listing Color"));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateColorCommand request)
        {
            await _mediator.Send(request);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204, "Create Successfully"));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateColorCommand request)
        {
            await _mediator.Send(request);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204, "Update Successfully"));
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] DeleteColorCommand request)
        {
            await _mediator.Send(request);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204, "Delete Successfully"));
        }
    }
}
