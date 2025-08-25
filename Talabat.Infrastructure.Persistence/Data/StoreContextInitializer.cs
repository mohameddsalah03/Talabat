using System.Text.Json;
using Talabat.Core.Domain.Contracts.Persistence;
using Talabat.Core.Domain.Entites.Products;

namespace Talabat.Infrastructure.Persistence.Data
{
    public class StoreContextInitializer(StoreContext _dbContext) : IStoreContextInitializer
    {
       
        public async Task InitializeAsync()
        {
            var pendingMigrations = await _dbContext.Database.GetPendingMigrationsAsync();
            if (pendingMigrations.Any())
               await _dbContext.Database.MigrateAsync(); //Update-Database
        }

        public async Task SeedAsync()
        {
            if (!_dbContext.Brands.Any())
            {
                var BrandsData = await File.ReadAllTextAsync(@"../Talabat.Infrastructure.Persistence/Data/Seeds/brands.json");
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(BrandsData, options);

                if (brands?.Count > 0)
                {
                    await _dbContext.Set<ProductBrand>().AddRangeAsync(brands);
                    await _dbContext.SaveChangesAsync();
                }

            }

            if (!_dbContext.Categories.Any())
            {
                var CategoriesData = await File.ReadAllTextAsync(@"../Talabat.Infrastructure.Persistence/Data/Seeds/categories.json");
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                var Categories = JsonSerializer.Deserialize<List<ProductCategory>>(CategoriesData, options);

                if (Categories?.Count > 0)
                {
                    await _dbContext.Set<ProductCategory>().AddRangeAsync(Categories);
                    await _dbContext.SaveChangesAsync();
                }

            }
            if (!_dbContext.Products.Any())
            {
                var ProductsData = await File.ReadAllTextAsync(@"../Talabat.Infrastructure.Persistence/Data/Seeds/products.json");
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                var Products = JsonSerializer.Deserialize<List<Product>>(ProductsData, options);

                if (Products?.Count > 0)
                {
                    await _dbContext.Set<Product>().AddRangeAsync(Products);
                    await _dbContext.SaveChangesAsync();
                }

            }


        }
    }
}
