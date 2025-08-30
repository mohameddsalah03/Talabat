using AutoMapper;
using Talabat.Core.Application.Abstraction.Common;
using Talabat.Core.Application.Abstraction.ModelsDtos.Products;
using Talabat.Core.Application.Abstraction.Services.Products;
using Talabat.Core.Domain.Contracts;
using Talabat.Core.Domain.Entites.Products;
using Talabat.Core.Domain.Specifications.Products;

namespace Talabat.Core.Application.Services.Products
{
    internal class ProductService(IUnitOfWork unitOfWork , IMapper mapper)  : IProductService
    {

        public async Task<Pagination<ProductToReturnDto>> GetProductsAsync(ProductSpecParams specParams)
        {
            var spec = new ProductWithBrandAndCategorySpecifications(specParams.Sort, specParams.BrandId, specParams.CategoryId , specParams.PageSize,specParams.PageIndex);
            var products = await unitOfWork.GetRepository<Product, int>().GetAllWithSpecAsync(spec);
            var data = mapper.Map<IEnumerable<ProductToReturnDto>>(products);
            //Count
            var specCount = new ProductWithFiltrationForCountSpecifications(specParams.BrandId, specParams.CategoryId);
            var count = await unitOfWork.GetRepository<Product,int>().GetCountAsync(specCount);
            
            return new Pagination<ProductToReturnDto>(specParams.PageIndex, specParams.PageSize , count) 
            { Data = data };
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
