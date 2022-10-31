using Microsoft.AspNetCore.Mvc;
using MiniECommerce.Application;

namespace MiniECommerce.Api.Controllers
{
    public class CustomBaseController : ControllerBase
    {
        [NonAction]
        //Ok.BadRequest.NoContent gibi dönüş tipleri yerine CustomResponseDto<T> ile statusCode, mesaj ve datayı dönebilecegimiz yapı oluşturduk.
        public IActionResult CreateActionResult<T>(CustomResponseDto<T> responseDto)
        {
            if (responseDto.StatusCode == 204)
                return new ObjectResult(null) { StatusCode = responseDto.StatusCode };

            return new ObjectResult(responseDto) { StatusCode = responseDto.StatusCode };
        }
    }
}
