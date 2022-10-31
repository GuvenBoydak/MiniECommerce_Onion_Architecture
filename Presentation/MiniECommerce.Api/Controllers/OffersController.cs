using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MiniECommerce.Application;

namespace MiniECommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OffersController : CustomBaseController
    {
        private readonly IMediator _mediator;

        public OffersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            List<OfferListDto> result = await _mediator.Send(new GetAllOfferQuery());

            return CreateActionResult(CustomResponseDto<List<OfferListDto>>.Success(200, result, "Listing All Offers"));
        }

        [HttpGet]
        [Route("getActive")]
        public async Task<IActionResult> GetActiveAsync()
        {
            List<OfferListDto> result = await _mediator.Send(new GetActiveOfferQuery());

            return CreateActionResult(CustomResponseDto<List<OfferListDto>>.Success(200, result, "Listing Active Offers"));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetByIDAsync([FromRoute] GetByIDOfferQuery request)
        {
            OfferDto result = await _mediator.Send(request);

            return CreateActionResult(CustomResponseDto<OfferDto>.Success(200, result, "Listing Offer"));
        }

        [HttpGet]
        [Route("{id}/getByAppUserMadeOffers")]
        public async Task<IActionResult> GetByAppUserMadeOffersAsync([FromRoute] GetByAppUserMadeOffersQuery request)
        {
            List<OfferListDto> result = await _mediator.Send(request);

            return CreateActionResult(CustomResponseDto<List<OfferListDto>>.Success(200, result, "Listing User made offers"));
        }

        [HttpGet]
        [Route("{id}/getByOffersFromAppUserProducts")]
        public async Task<IActionResult> GetByOffersFromAppUserProductsAsync([FromRoute] GetByOffersFromAppUserProductsQuery request)
        {
            List<OfferListDto> result = await _mediator.Send(request);

            return CreateActionResult(CustomResponseDto<List<OfferListDto>>.Success(200, result, "Listing offers to the user's products "));
        }

        [HttpGet]
        [Route("{id}/getByOffersOnTheProduct")]
        public async Task<IActionResult> GetByOffersOnTheProductAsync([FromRoute] GetByOffersOnTheProductQuery request)
        {
            List<OfferListDto> result = await _mediator.Send(request);

            return CreateActionResult(CustomResponseDto<List<OfferListDto>>.Success(200, result, "Listing offer for the product"));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateBrandCommand request)
        {
            await _mediator.Send(request);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204, "Create Successfully"));
        }

        [HttpPost]
        [Route("buyProduct")]
        public async Task<IActionResult> BuyProductAsync([FromBody] BuyProductCommand request)
        {
            await _mediator.Send(request);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204, "Create Purchasing"));
        }

        [HttpPost]
        [Route("offerApproval")]
        public async Task<IActionResult> OfferApprovalAsync([FromBody] OfferApprovalCommand request)
        {
            await _mediator.Send(request);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204, "Offer approved Purchasing"));
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
