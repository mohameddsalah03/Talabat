using System.Security.Claims;
using Talabat.Shared.DTOs.Auth;
using Talabat.Shared.DTOs.Common;

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
