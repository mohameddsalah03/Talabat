﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Domain.Entites.Identity;

namespace Talabat.Core.Application.Extensions
{
    internal static class UserManagerExtensions
    {
        public static async Task<ApplicationUser?> FindUserWithAddress(this UserManager<ApplicationUser> userManager , ClaimsPrincipal claimsPrincipal)
        {
            var email = claimsPrincipal.FindFirstValue(ClaimTypes.Email);

            var user = userManager.Users.Where(user=>user.Email==email)
                                        .Include(user=>user.Address)
                                        .FirstOrDefault();

            return user;
        }
    }
}
