using Talabat.Core.Application.Abstraction.Dtos.Products;

namespace Talabat.Core.Application.Abstraction.Services.Products
{
    public interface IProductService
    {
        Task<IEnumerable<ProductToReturnDto>> GetProductsAsync();

        Task<ProductToReturnDto> GetProductAsync(int id);

        Task<IEnumerable<BrandDto>> GetBrandsAsync();
        Task<IEnumerable<CategoryDto>> GetCategoriesAsync();

    }
}
