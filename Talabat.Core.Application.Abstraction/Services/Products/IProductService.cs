using Talabat.Core.Application.Abstraction.Common;
using Talabat.Core.Application.Abstraction.ModelsDtos.Products;

namespace Talabat.Core.Application.Abstraction.Services.Products
{
    public interface IProductService
    {
        Task<Pagination<ProductToReturnDto>> GetProductsAsync(ProductSpecParams specParams);

        Task<ProductToReturnDto> GetProductAsync(int id);

        Task<IEnumerable<BrandDto>> GetBrandsAsync();
        Task<IEnumerable<CategoryDto>> GetCategoriesAsync();

    }
}
