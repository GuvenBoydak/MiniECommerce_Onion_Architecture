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
    public class BrandsController : CustomBaseController
    {
        private readonly IMediator _mediator;

        public BrandsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            List<BrandListDto> result = await _mediator.Send(new GetAllBrandQuery());

            return CreateActionResult(CustomResponseDto<List<BrandListDto>>.Success(200, result, "Listing All Brands"));
        }

        [HttpGet]
        [Route("getActive")]
        public async Task<IActionResult> GetActiveAsync()
        {
            List<BrandListDto> result = await _mediator.Send(new GetActiveBrandQuery());

            return CreateActionResult(CustomResponseDto<List<BrandListDto>>.Success(200, result, "Listing Active Brands"));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetByIDAsync([FromRoute] GetByIDBrandQuery request)
        {
            BrandDto result = await _mediator.Send(request);

            return CreateActionResult(CustomResponseDto<BrandDto>.Success(200, result, "Listing Brand"));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateBrandCommand request)
        {
            await _mediator.Send(request);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204, "Create Successfully"));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateBrandCommand request)
        {
            await _mediator.Send(request);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204, "Update Successfully"));
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] DeleteBrandCommand request)
        {
            await _mediator.Send(request);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204, "Delete Successfully"));
        }
    }
}
