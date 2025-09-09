using Microsoft.AspNetCore.Mvc;
using Talabat.APIs.Controllers.Controllers.Base;
using Talabat.Core.Application.Abstraction.Services;
using Talabat.Shared.DTOs.Common;
using Talabat.Shared.DTOs.Products;

namespace Talabat.APIs.Controllers.Controllers.Products
{
    public class ProductsController(IServiceManager serviceManager) : BaseApiController
    {

        //[Authorize]
        [HttpGet] //Get: /api/Products
        public async Task<ActionResult<Pagination<ProductToReturnDto>>>  GetProducts([FromQuery] ProductSpecParams specParams)
        {
            var products = await serviceManager.ProductService.GetProductsAsync( specParams);
            return Ok(products);
        }

        //Get Produtc by id
        [HttpGet( "{id:int}")] //Get: /api/Products/id
        public async Task<ActionResult<ProductToReturnDto>>  GetProduct(int id)
        { 
            var product = await serviceManager.ProductService.GetProductAsync(id);
            return Ok(product);
        }


        //Get All Brands
        [HttpGet("brands")] //Get: /api/Products/brands
        public async Task<ActionResult<IEnumerable<BrandDto>>> GetBrands()
        {
            var brands = await serviceManager.ProductService.GetBrandsAsync();
            return Ok(brands);
        }

        //Get All categories
        [HttpGet("categories")] //Get: /api/Products/categories
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetCategories()
        {
            var categories = await serviceManager.ProductService.GetCategoriesAsync();
            return Ok(categories);
        }



    }
}
