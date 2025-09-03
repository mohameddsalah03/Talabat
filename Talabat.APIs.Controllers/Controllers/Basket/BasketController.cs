using Microsoft.AspNetCore.Mvc;
using Talabat.APIs.Controllers.Controllers.Base;
using Talabat.Core.Application.Abstraction.ModelsDtos.Basket;
using Talabat.Core.Application.Abstraction.Services;

namespace Talabat.APIs.Controllers.Controllers.Basket
{

    public class BasketController(IServiceManager serviceManager) : BaseApiController
    {

        [HttpGet] // Get: /api/Basket?id=
        public async Task<ActionResult<CustomerBasketDto>> GetBasket(string basketId)
        {
            var basket = await serviceManager.BasketService.GetCustomerBasketAsync(basketId);
            return Ok(basket);
        }


        [HttpPost] // Post: /api/Basket
        public async Task<ActionResult<CustomerBasketDto>> UpdateBasket(CustomerBasketDto basketDto)
        {
            var basket = await serviceManager.BasketService.UpdateCustomerBasketAsync(basketDto);
            return Ok(basket);
        }


        [HttpDelete] // Delete: /api/Basket
        public async Task DeleteBasket(string basketId)
        {
            await serviceManager.BasketService.DeleteCustomerBasketAsync(basketId);
        }

    }
}
