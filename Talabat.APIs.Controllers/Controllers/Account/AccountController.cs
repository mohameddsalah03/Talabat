using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Talabat.APIs.Controllers.Controllers.Base;
using Talabat.Core.Application.Abstraction.Common;
using Talabat.Core.Application.Abstraction.ModelsDtos.Auth;
using Talabat.Core.Application.Abstraction.Services;

namespace Talabat.APIs.Controllers.Controllers.Account
{
    public class AccountController(IServiceManager serviceManager) : BaseApiController
    {

        [HttpPost("login")] //Post: /api/account/login
        public async Task<ActionResult<UserDto>> Login(LoginDto model)
        {
            var user = await serviceManager.AuthService.LoginAysnc(model);
            return Ok(user);
        }

        [HttpPost("register")] //Post: /api/account/register
        public async Task<ActionResult<UserDto>> Register(RegisterDto model)
        {
            var user = await serviceManager.AuthService.RegisterAsync(model);
            return Ok(user);
        }

        [Authorize]
        [HttpGet] //Get: /api/account
        public async Task<ActionResult<UserDto>> GetCurrentUser()
        {
            var result = await serviceManager.AuthService.GetCurrentUser(User);
            return Ok(result);
        }
       
        [Authorize]
        [HttpGet("address")] //Get: /api/account/address
        public async Task<ActionResult<AddressDto>> GetUserAddress()
        {
            var result = await serviceManager.AuthService.GetUserAddress(User);
            return Ok(result);
        }
       
        [Authorize]
        [HttpPut("address")] //Put: /api/account/address
        public async Task<ActionResult<AddressDto>> UpdateUserAddress(AddressDto addressDto)
        {
            var result = await serviceManager.AuthService.UpdateUserAddress(User , addressDto);
            return Ok(result);
        }
       
       
        
        [HttpGet("emailexists")] //Put: /api/account/emailexists?email= ahmed.gmail.com
        public async Task<ActionResult<bool>> CheckEmailExists(string email)
        {
            var result = await serviceManager.AuthService.EmailExists(email);
            return Ok(result);
        }
       


    }
}
