using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Talabat.Core.Domain.Contracts;
using Talabat.Core.Domain.Contracts.Persistence;
using Talabat.Infrastructure.Persistence.Data;
using Talabat.Infrastructure.Persistence.Data.Interceptors;

namespace Talabat.Infrastructure.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services , IConfiguration configuration)
        {
            services.AddDbContext<StoreContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("StoreContext"));
            });

            //
            services.AddScoped<IStoreContextInitializer , StoreContextInitializer>();

            //
            services.AddScoped(typeof(ISaveChangesInterceptor), typeof(CustomSaveChangesInterceptors));

            //
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork.UnitOfWork));

            return services;
        }
    
    }
}
