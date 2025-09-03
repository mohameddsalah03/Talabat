using Microsoft.Extensions.DependencyInjection;
using Talabat.Core.Application.Abstraction.Services;
using Talabat.Core.Application.Abstraction.Services.Auth;
using Talabat.Core.Application.Abstraction.Services.Basket;
using Talabat.Core.Application.Mapping;
using Talabat.Core.Application.Services;
using Talabat.Core.Application.Services.Auth;
using Talabat.Core.Application.Services.Basket;

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

            ///  basket service Factory 
            /// services.AddScoped(typeof(Func<IBasketService>), (serviceProvider) =>
            /// {
            ///     var basketrepository = serviceProvider.GetRequiredService<IBasketRepository>();
            ///     var mapper = serviceProvider.GetRequiredService<IMapper>();
            ///     var configuration = serviceProvider.GetRequiredService<IConfiguration>();
            ///   
            ///     return () => new BasketService(basketrepository,mapper,configuration);
            /// });

            return services;
        }

    }
}
