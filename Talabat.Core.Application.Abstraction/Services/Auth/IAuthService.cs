using Talabat.Core.Application.Abstraction.ModelsDtos.Auth;

namespace Talabat.Core.Application.Abstraction.Services.Auth
{
    public interface IAuthService
    {
        Task<UserDto> LoginAysnc(LoginDto model);

        Task<UserDto> RegisterAsync(RegisterDto model);
    }
}
