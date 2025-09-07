using Talabat.Core.Domain.Contracts.Persistence.DbInitializers;

namespace Talabat.Infrastructure.Persistence.Common
{
    public abstract class DbInitializer(DbContext dbContext) : IDbInitializer
    {
        public virtual async Task InitializeAsync()
        {
            var pendingMigrations = await dbContext.Database.GetPendingMigrationsAsync();
            if (pendingMigrations.Any())
                await dbContext.Database.MigrateAsync(); //Update-Database
        }

        public abstract Task SeedAsync();
        
    }
}
