using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Talabat.APIs.Controllers.Controllers.Base;
using Talabat.APIs.Controllers.Errors;
using Talabat.Core.Application.Abstraction.Services;

namespace Talabat.APIs.Controllers.Controllers.Byggy
{
    public class BuggyController : BaseApiController
    {
        public BuggyController(IServiceManager serviceManager)
            : base()
        {
            
        }

        
        [HttpGet("not-found")] // Get: baseUrl/api/Buggy/not-found
        public IActionResult GetNotFoundRequest()
        {
            return NotFound (new ApiResponse(404));
            //return NotFound(new { Message = "NotFound!" ,StatusCode = 404 }); //404
            ////return NotFound();
            
        }


        [HttpGet("server-error")] // Get: baseUrl/api/Buggy/server-error
        public IActionResult GetServerErrorRequest()
        {
            throw new Exception(); //500
        }

        [HttpGet("bad-request")] // Get: baseUrl/api/Buggy/bad-request
        public IActionResult GetBadRequestRequest()
        {
            return BadRequest(new ApiResponse(400));

            //return BadRequest(new { Message = "BadRequest!", StatusCode = 400 }); //400
        }


        [HttpGet("bad-request/{id}")] // Get: baseUrl/api/Buggy/bad-request/id= five
        public IActionResult GetValidationErrorRequest(int id)
        {
            return Ok(); 
        }

        
        [HttpGet("unauthorized")] // Get: baseUrl/api/Buggy/unauthorized
        public IActionResult GetUnauthorizedErrorRequest()
        {
            return Unauthorized(new ApiResponse(401));

            //return Unauthorized(new { Message = "Unauthorized!", StatusCode = 401 }); //401
        }

        [HttpGet("forbidden")] // Get: baseUrl/api/Buggy/forbidden
        public IActionResult GetForbiddenErrorRequest()
        {
            return Forbid(); //403
        }



    }
}
