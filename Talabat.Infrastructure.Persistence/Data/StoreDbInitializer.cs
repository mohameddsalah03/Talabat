using System.Text.Json;
using Talabat.Core.Domain.Contracts.Persistence.DbInitializers;
using Talabat.Core.Domain.Entites.Orders;
using Talabat.Core.Domain.Entites.Products;
using Talabat.Infrastructure.Persistence.Common;

namespace Talabat.Infrastructure.Persistence.Data
{
    public class StoreDbInitializer(StoreContext dbContext) :
        DbInitializer(dbContext),
        IStoreDbInitializer
    {
       
        public override async Task SeedAsync()
        {
            if (!dbContext.Brands.Any())
            {
                var BrandsData = await File.ReadAllTextAsync(@"../Talabat.Infrastructure.Persistence/Data/Seeds/brands.json");
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(BrandsData, options);

                if (brands?.Count > 0)
                {
                    await dbContext.Set<ProductBrand>().AddRangeAsync(brands);
                    await dbContext.SaveChangesAsync();
                }

            }
            if (!dbContext.Categories.Any())
            {
                var CategoriesData = await File.ReadAllTextAsync(@"../Talabat.Infrastructure.Persistence/Data/Seeds/categories.json");
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                var Categories = JsonSerializer.Deserialize<List<ProductCategory>>(CategoriesData, options);

                if (Categories?.Count > 0)
                {
                    await dbContext.Set<ProductCategory>().AddRangeAsync(Categories);
                    await dbContext.SaveChangesAsync();
                }

            }
            if (!dbContext.Products.Any())
            {
                var ProductsData = await File.ReadAllTextAsync(@"../Talabat.Infrastructure.Persistence/Data/Seeds/products.json");
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                var Products = JsonSerializer.Deserialize<List<Product>>(ProductsData, options);

                if (Products?.Count > 0)
                {
                    await dbContext.Set<Product>().AddRangeAsync(Products);
                    await dbContext.SaveChangesAsync();
                }

            }


            if (!dbContext.DeliveryMethods.Any())
            {
                var deliveriesData = await File.ReadAllTextAsync(@"../Talabat.Infrastructure.Persistence/Data/Seeds/delivery.json");
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                var deliveries = JsonSerializer.Deserialize<List<DeliveryMethod>>(deliveriesData, options);

                if (deliveries?.Count > 0)
                {
                    await dbContext.Set<DeliveryMethod>().AddRangeAsync(deliveries);
                    await dbContext.SaveChangesAsync();
                }

            }


        }
    }
}
