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
    public class ProductsController : CustomBaseController
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            List<ProductListDto> result = await _mediator.Send(new GetAllProductQuery());

            return CreateActionResult(CustomResponseDto<List<ProductListDto>>.Success(200, result, "Listing All Products"));
        }

        [HttpGet]
        [Route("getActive")]
        public async Task<IActionResult> GetActiveAsync()
        {
            List<ProductListDto> result = await _mediator.Send(new GetActiveProductQuery());

            return CreateActionResult(CustomResponseDto<List<ProductListDto>>.Success(200, result, "Listing Active Products"));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetByIDAsync([FromRoute] GetByIDProductQuery request)
        {
            ProductDto result = await _mediator.Send(request);

            return CreateActionResult(CustomResponseDto<ProductDto>.Success(200, result, "Listing Product"));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateProductCommand request)
        {
            await _mediator.Send(request);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204, "Create Successfully"));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateProductCommand request)
        {
            await _mediator.Send(request);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204, "Update Successfully"));
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] DeleteProductCommand request)
        {
            await _mediator.Send(request);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204, "Delete Successfully"));
        }
    }
}
