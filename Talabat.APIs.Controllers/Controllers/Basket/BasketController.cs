using Microsoft.AspNetCore.Mvc;
using Talabat.APIs.Controllers.Controllers.Base;
using Talabat.Core.Application.Abstraction.Common.Contracts.Infrastructure;
using Talabat.Shared.DTOs.Basket;

namespace Talabat.APIs.Controllers.Controllers.Basket
{

    public class BasketController(IBasketService basketService) : BaseApiController
    {

        [HttpGet] // Get: /api/Basket?id=
        public async Task<ActionResult<CustomerBasketDto>> GetBasket(string basketId)
        {
            var basket = await basketService.GetCustomerBasketAsync(basketId);
            return Ok(basket);
        }


        [HttpPost] // Post: /api/Basket
        public async Task<ActionResult<CustomerBasketDto>> UpdateBasket(CustomerBasketDto basketDto)
        {
            var basket = await basketService.UpdateCustomerBasketAsync(basketDto);
            return Ok(basket);
        }


        [HttpDelete] // Delete: /api/Basket
        public async Task DeleteBasket(string basketId)
        {
            await basketService.DeleteCustomerBasketAsync(basketId);
        }

    }
}
