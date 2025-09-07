using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Talabat.Core.Domain.Contracts;
using Talabat.Core.Domain.Contracts.Persistence.DbInitializers;
using Talabat.Infrastructure.Persistence.Data;
using Talabat.Infrastructure.Persistence.Data.Interceptors;
using Talabat.Infrastructure.Persistence.Identity;


namespace Talabat.Infrastructure.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services , IConfiguration configuration)
        {
            #region StoreContext , StoreInitializer and AuditInterceptors

            services.AddDbContext<StoreContext>( (serviceProvider ,optionsBuilder)  =>
            {
                optionsBuilder
                //.UseLazyLoadingProxies()
                .UseSqlServer(configuration.GetConnectionString("StoreContext"))
                .AddInterceptors(serviceProvider.GetRequiredService<AuditInterceptors>());
            });

            //
            services.AddScoped<IStoreDbInitializer, StoreDbInitializer>();

            services.AddScoped(typeof(AuditInterceptors));

            #endregion
            //
           
            //
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork.UnitOfWork));


            #region IdentityContext And IdentityInitializer

            services.AddDbContext<StoreIdentityDbContext>(options =>
            {
                options
                //.UseLazyLoadingProxies()
                .UseSqlServer(configuration.GetConnectionString("IdentityContext"));
            });

            //
            services.AddScoped(typeof(IStoreIdentityDbInitializer), typeof(StoreIdentityDbInitializer));

            #endregion

           


             
            return services;
        }
    
    }
}
