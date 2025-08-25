using Microsoft.EntityFrameworkCore.Diagnostics;
using Talabat.Core.Application.Abstraction;
using Talabat.Core.Domain.Common;

namespace Talabat.Infrastructure.Persistence.Data.Interceptors
{
    internal class CustomSaveChangesInterceptors : SaveChangesInterceptor
    {
        private readonly ILoggedInUserService _loggedInUserService;

        public CustomSaveChangesInterceptors(ILoggedInUserService loggedInUserService)
        {
            _loggedInUserService = loggedInUserService;
        }


        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            UpdateEntites(eventData.Context);
            return base.SavingChanges(eventData, result);
        }


        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            UpdateEntites(eventData.Context);
            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        private void UpdateEntites(DbContext? dbContext)
        {
            if (dbContext == null) return;
            
            foreach (var entry in dbContext.ChangeTracker.Entries<BaseAuditableEntity<int>>()
                .Where(entity=>entity.State is EntityState.Added or EntityState.Modified))
            {
                if (entry.State is EntityState.Added)
                {
                    entry.Entity.CreatedBy = _loggedInUserService.UserId!;
                    entry.Entity.CreatedOn = DateTime.UtcNow;
                }
                entry.Entity.LastModifiedBy = _loggedInUserService.UserId!;
                entry.Entity.LastModifiedOn = DateTime.UtcNow;

            }
        }

    }
}
