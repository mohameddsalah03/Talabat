using Microsoft.AspNetCore.Mvc;
using Talabat.APIs.Controllers.Controllers.Base;
using Talabat.Core.Application.Abstraction.Dtos.Products;
using Talabat.Core.Application.Abstraction.Services;

namespace Talabat.APIs.Controllers.Controllers.Products
{
    public class ProductsController(IServiceManager serviceManager) : BaseApiController
    {

        //Get All Produtcs
        [HttpGet] //Get: /api/Products
        public async Task<ActionResult<IEnumerable<ProductToReturnDto>>>  GetProducts()
        {
            var products = await serviceManager.ProductService.GetProductsAsync();
            return Ok(products);
        }

        //Get Produtc by id
        [HttpGet( "{id:int}")] //Get: /api/Products/id
        public async Task<ActionResult<ProductToReturnDto>>  GetProduct(int id)
        {
            var product = await serviceManager.ProductService.GetProductAsync(id);

            if (product is null)
                return NotFound(new {StatusCode = 404 ,message = "Not Found!" });

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
