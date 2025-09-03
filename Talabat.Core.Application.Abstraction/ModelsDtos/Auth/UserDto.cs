using System.ComponentModel.DataAnnotations;

namespace Talabat.Core.Application.Abstraction.ModelsDtos.Auth
{
    public class UserDto
    {
        [Required]
        public required string Id { get; set; }

        [Required]
        public required string DisplayName { get; set; }

        [Required]
        public required string Email { get; set; }

        [Required]
        public required string Token { get; set; }
    }
}
