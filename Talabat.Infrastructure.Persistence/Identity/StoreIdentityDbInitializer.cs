using Microsoft.AspNetCore.Identity;
using Talabat.Core.Domain.Contracts.Persistence.DbInitializers;
using Talabat.Core.Domain.Entites.Identity;
using Talabat.Infrastructure.Persistence.Common;

namespace Talabat.Infrastructure.Persistence.Identity
{
    public class StoreIdentityDbInitializer(
        StoreIdentityDbContext dbContext,
        UserManager<ApplicationUser> userManager
        ) 
        : DbInitializer (dbContext),IStoreIdentityDbInitializer
    {
        public override async Task SeedAsync()
        {
            if (! userManager.Users.Any())
            {
                var user = new ApplicationUser()
                {
                    DisplayName = "mohamed salah",
                    UserName = "mohammed.salah",
                    Email = "mohammed.salah@gmail.com",
                    PhoneNumber = "01242374632"
                };

                await userManager.CreateAsync(user, "P@ssw0rd");

            }
        }
    }
}
