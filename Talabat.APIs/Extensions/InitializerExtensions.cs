using Talabat.Core.Domain.Contracts.Persistence;

namespace Talabat.APIs.Extensions
{
    public static class InitializerExtensions
    {
        // generate Object From DbInitializer Explicitly
        public static async Task<WebApplication> InitializeStoreContext(this WebApplication app)
        {
            using var scope = app.Services.CreateAsyncScope();
            var services = scope.ServiceProvider;
            var StoreContextInitializer = services.GetRequiredService<IStoreContextInitializer>();

            var loggerFactory = services.GetRequiredService<ILoggerFactory>();

            try
            {
                await StoreContextInitializer.InitializeAsync();
                await StoreContextInitializer.SeedAsync();

            }
            catch (Exception ex)
            {

                var logger = loggerFactory.CreateLogger<Program>();
                logger.LogError(ex, "An Error Has Been Occured during applying the migrations !");

            }
           
            return app;

        }
    }
}
