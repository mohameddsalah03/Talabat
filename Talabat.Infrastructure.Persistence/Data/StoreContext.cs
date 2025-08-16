using Talabat.Core.Domain.Entites.Products;

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
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AssemblyInformation).Assembly);
        }

        #region DbSets

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductBrand> Brands { get; set; }
        public DbSet<ProductCategory> Categories { get; set; }

        #endregion


    }
}
