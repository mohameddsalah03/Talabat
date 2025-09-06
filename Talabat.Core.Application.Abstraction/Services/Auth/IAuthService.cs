using System.Security.Claims;
using Talabat.Core.Application.Abstraction.Common;
using Talabat.Core.Application.Abstraction.ModelsDtos.Auth;

namespace Talabat.Core.Application.Abstraction.Services.Auth
{
    public interface IAuthService
    {
        Task<UserDto> LoginAysnc(LoginDto loginDto);

        Task<UserDto> RegisterAsync(RegisterDto registerDto);

        Task<UserDto> GetCurrentUser(ClaimsPrincipal claimsPrincipal);

        Task<AddressDto?> GetUserAddress(ClaimsPrincipal claimsPrincipal);

        Task<AddressDto?> UpdateUserAddress(ClaimsPrincipal claimsPrincipal , AddressDto addressdto);

        Task<bool> EmailExists(string email);
    }
}
