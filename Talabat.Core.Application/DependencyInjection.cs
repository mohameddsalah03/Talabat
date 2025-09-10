using Microsoft.Extensions.DependencyInjection;
using Talabat.Core.Application.Abstraction.Common.Contracts.Infrastructure;
using Talabat.Core.Application.Abstraction.Services;
using Talabat.Core.Application.Abstraction.Services.Auth;
using Talabat.Core.Application.Abstraction.Services.Orders;
using Talabat.Core.Application.Mapping;
using Talabat.Core.Application.Services;
using Talabat.Core.Application.Services.Auth;
using Talabat.Core.Application.Services.Basket;
using Talabat.Core.Application.Services.Orders;

namespace Talabat.Core.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {

            services.AddAutoMapper(typeof(MappingProfile));

            // Service Manager
            services.AddScoped(typeof(IServiceManager), typeof(ServiceManager));
              
            // BasketService
            services.AddScoped<IBasketService, BasketService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IOrderService, OrderService>();

           

            return services;
        }

    }
}
