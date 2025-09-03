﻿using System.ComponentModel.DataAnnotations;

namespace Talabat.Core.Application.Abstraction.ModelsDtos.Auth
{
    public class LoginDto
    {
        [Required]
        [EmailAddress]
        public required string Email { get; set; }

        [Required]
        public required string Password { get; set; }
    }
}
