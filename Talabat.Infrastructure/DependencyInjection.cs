using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;
using Talabat.Core.Domain.Contracts.Infrastructure;
using Talabat.Infrastructure.BasketRepositores;

namespace Talabat.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services , IConfiguration configuration)
        {

            services.AddSingleton(typeof(IConnectionMultiplexer), (serviceProvider) =>
            {
                return ConnectionMultiplexer.Connect(configuration.GetConnectionString("Redis")!);
            });

            services.AddScoped(typeof(IBasketRepository),typeof(BasketRepository));

            return services;
        }

    }
}
