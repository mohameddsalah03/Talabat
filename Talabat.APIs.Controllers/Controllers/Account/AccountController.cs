using Microsoft.AspNetCore.Mvc;
using Talabat.APIs.Controllers.Controllers.Base;
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

       

    }
}
