using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.APIs.Controllers.Errors;

namespace Talabat.APIs.Controllers.Controllers.Common
{
    [ApiController]
    [Route("Errors/{code}")]
    [ApiExplorerSettings(IgnoreApi =true)]
    public class ErrorsController : ControllerBase
    {
        [HttpGet]
        public IActionResult Error(int code)
        {
            if (code == StatusCodes.Status404NotFound)
            {
                var response = new ApiResponse(StatusCodes.Status404NotFound, $"The Request EndPoint Is Not Found");
                return NotFound(response);
            }

            return StatusCode(code,new ApiResponse(code));
        }
    }
}
