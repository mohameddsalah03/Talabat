using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Talabat.Core.Application.Abstraction.ModelsDtos.Auth;
using Talabat.Core.Application.Abstraction.Services.Auth;
using Talabat.Core.Application.Exceptions;
using Talabat.Core.Domain.Entites.Identity;

namespace Talabat.Core.Application.Services.Auth
{
    public class AuthService(
        UserManager<ApplicationUser> userManager ,
        SignInManager<ApplicationUser> signInManager,
        IOptions<JwtSettings> jwtSettings
        ) : IAuthService
    {
        private readonly JwtSettings _jwtSettings = jwtSettings.Value;

        public async Task<UserDto> LoginAysnc(LoginDto model)
        {
            var user = await userManager.FindByEmailAsync(model.Email);
            if (user is null) throw new UnauthorizedException("Invalid Login");

            var result = await signInManager.CheckPasswordSignInAsync(user, model.Password ,lockoutOnFailure:true);
            
            if(result.IsNotAllowed) throw new UnauthorizedException("Account Not Confirmed Yet.");
            if(result.IsLockedOut) throw new UnauthorizedException("Account Is Locked.");
            if(!result.Succeeded) throw new UnauthorizedException("Invalid Login."); // Must in Last

            var response = new UserDto()
            {
                Id = user.Id,
                DisplayName = user.DisplayName,
                Email = user.Email!,
                Token =await GenerateTokenAsync(user),
            };

            return response;

        }

        public async Task<UserDto> RegisterAsync(RegisterDto model)
        {
            var user = new ApplicationUser()
            {
                DisplayName = model.DisplayName,
                Email = model.Email,
                UserName = model.UserName,  
                PhoneNumber = model.PhoneNumber,
            };

            var result = await userManager.CreateAsync(user , model.Password);

            if(!result.Succeeded) throw new ValidationException() { Errors = result.Errors.Select(E=>E.Description) };

            var response = new UserDto()
            {
                Id = user.Id,
                DisplayName = user.DisplayName,
                Email = user.Email!,
                Token = await GenerateTokenAsync(user),
            };
            
            return response;    
        }

        private async Task<string> GenerateTokenAsync(ApplicationUser user)
        {
            var userCliams = await userManager.GetClaimsAsync(user);
            
            var rolesAsCliams = new List<Claim>();
            var rolesClaims = await userManager.GetRolesAsync(user);
            foreach (var role in rolesClaims) 
                rolesAsCliams.Add(new Claim(ClaimTypes.Role,role.ToString()));   

            var authClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.PrimarySid, user.Id),
                new Claim(ClaimTypes.Email, user.Email!),
                new Claim(ClaimTypes.GivenName, user.DisplayName),
            }
            .Union(userCliams)
            .Union(rolesAsCliams);
            ;

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var signInCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var tokenObj = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
                claims: authClaims,
                signingCredentials: signInCredentials
                );

            return new JwtSecurityTokenHandler().WriteToken(tokenObj);  
        }

    }
}
