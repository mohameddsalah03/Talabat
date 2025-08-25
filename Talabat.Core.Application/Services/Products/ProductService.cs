using AutoMapper;
using Talabat.Core.Application.Abstraction.Dtos.Products;
using Talabat.Core.Application.Abstraction.Services.Products;
using Talabat.Core.Domain.Contracts;
using Talabat.Core.Domain.Entites.Products;
using Talabat.Core.Domain.Specifications.Products;

namespace Talabat.Core.Application.Services.Products
{
    internal class ProductService(IUnitOfWork unitOfWork , IMapper mapper)  : IProductService
    {

        public async Task<IEnumerable<ProductToReturnDto>> GetProductsAsync()
        {
            var spec = new ProductWithBrandAndCategorySpecifications();
            var products = await unitOfWork.GetRepository<Product, int>().GetAllWithSpecAsync(spec);
            var productsToReturn = mapper.Map<IEnumerable<ProductToReturnDto>>(products);
            return productsToReturn;
        }

        public async Task<ProductToReturnDto> GetProductAsync(int id)
        {
            var spec = new ProductWithBrandAndCategorySpecifications(id);
            var product = await unitOfWork.GetRepository<Product, int>().GetWithSpecAsync(spec);
            var productToReturn = mapper.Map<ProductToReturnDto>(product);
            return productToReturn;
        }

        public async Task<IEnumerable<BrandDto>> GetBrandsAsync()
        {

            var brands = await unitOfWork.GetRepository<ProductBrand, int>().GetAllAsync();
            var brandsToReturn = mapper.Map<IEnumerable<BrandDto>>(brands);
            return brandsToReturn;
        }

        public async Task<IEnumerable<CategoryDto>> GetCategoriesAsync()
        {
            var categories = await unitOfWork.GetRepository<ProductCategory, int>().GetAllAsync();
            var categoriesToReturn = mapper.Map<IEnumerable<CategoryDto>>(categories);
            return categoriesToReturn;
        }

    }
}
