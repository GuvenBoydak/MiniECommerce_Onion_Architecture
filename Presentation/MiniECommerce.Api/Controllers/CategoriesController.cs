using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MiniECommerce.Application;

namespace MiniECommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoriesController : CustomBaseController
    {
        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            List<CategoryListDto> result = await _mediator.Send(new GetAllCategoryQuery());

            return CreateActionResult(CustomResponseDto<List<CategoryListDto>>.Success(200, result, "Listing All Categories"));
        }

        [HttpGet]
        [Route("getActive")]
        public async Task<IActionResult> GetActiveAsync()
        {
            List<CategoryListDto> result = await _mediator.Send(new GetActiveCategoryQuery());

            return CreateActionResult(CustomResponseDto<List<CategoryListDto>>.Success(200, result, "Listing Active Categories"));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetByIDAsync([FromRoute] GetByIDCategoryQuery request)
        {
            CategoryDto result = await _mediator.Send(request);

            return CreateActionResult(CustomResponseDto<CategoryDto>.Success(200, result, "Listing Category"));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateCategoryCommand request)
        {
            await _mediator.Send(request);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204, "Create Successfully"));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateCategoryCommand request)
        {
            await _mediator.Send(request);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204, "Update Successfully"));
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] DeleteCategoryCommand request)
        {
            await _mediator.Send(request);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204, "Delete Successfully"));
        }
    }
}
