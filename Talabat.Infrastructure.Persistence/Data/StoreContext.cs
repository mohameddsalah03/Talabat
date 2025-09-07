using System.Reflection;
using Talabat.Core.Domain.Entites.Orders;
using Talabat.Core.Domain.Entites.Products;
using Talabat.Infrastructure.Persistence.Common;

namespace Talabat.Infrastructure.Persistence.Data
{
    public class StoreContext : DbContext
    {

        #region Ctor

        public StoreContext(DbContextOptions<StoreContext> options) 
            : base(options) { }

        #endregion


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(AssemblyInformation).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(StoreContext).Assembly,
                type => type.GetCustomAttribute<DbContextTypeAttribute>()?.DbContextType == typeof(StoreContext));

        }

        #region DbSets

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductBrand> Brands { get; set; }
        public DbSet<ProductCategory> Categories { get; set; }
        
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<DeliveryMethod> DeliveryMethods { get; set; }


        #endregion


    }
}
