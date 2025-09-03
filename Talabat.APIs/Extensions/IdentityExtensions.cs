﻿using Microsoft.AspNetCore.Identity;
using Talabat.Core.Application.Abstraction.ModelsDtos.Auth;
using Talabat.Core.Domain.Entites.Identity;
using Talabat.Infrastructure.Persistence.Identity;

namespace Talabat.APIs.Extensions
{
    public static class IdentityExtensions
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services , IConfiguration configuration)
        {
            services.Configure<JwtSettings>(configuration.GetSection("jwtSttings"));

             services.AddIdentity<ApplicationUser, IdentityRole>(identityOptions =>
             {
                    // For User
                    identityOptions.User.RequireUniqueEmail = true;

                    // For SignIn
                    // identityOptions.SignIn.RequireConfirmedEmail = true;
                    // identityOptions.SignIn.RequireConfirmedAccount = true;
                    // identityOptions.SignIn.RequireConfirmedPhoneNumber = true;

                    // For Password
                    // identityOptions.Password.RequireNonAlphanumeric = true;
                    // identityOptions.Password.RequiredUniqueChars = 2;
                    // identityOptions.Password.RequiredLength= 6;
                    // identityOptions.Password.RequireUppercase = true;
                    // identityOptions.Password.RequireLowercase = true;
                    // identityOptions.Password.RequireDigit = true;
             })
               .AddEntityFrameworkStores<StoreIdentityDbContext>();
                            
            return services;    
        }
    }
}
