using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Reflection;
using Talabat.Core.Domain.Entites.Identity;
using Talabat.Infrastructure.Persistence.Common;

namespace Talabat.Infrastructure.Persistence.Identity
{
    public class StoreIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public StoreIdentityDbContext(DbContextOptions<StoreIdentityDbContext> options)
            : base(options)
        {
     
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder); // Must Keep It

            //builder.ApplyConfiguration(new ApplicationUserConfigurations());
            //builder.ApplyConfiguration(new AddressConfigurations());
            builder.ApplyConfigurationsFromAssembly(typeof(StoreIdentityDbContext).Assembly,
                type => type.GetCustomAttribute<DbContextTypeAttribute>()?.DbContextType == typeof(StoreIdentityDbContext));


        }

    }
}
