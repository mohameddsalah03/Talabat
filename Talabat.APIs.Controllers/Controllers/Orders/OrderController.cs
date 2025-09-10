using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Talabat.APIs.Controllers.Controllers.Base;
using Talabat.Core.Application.Abstraction.Services;
using Talabat.Shared.DTOs.Orders;

namespace Talabat.APIs.Controllers.Controllers.Orders
{
    [Authorize]
    public class OrdersController(IServiceManager serviceManager) : BaseApiController
    {

        [HttpPost] //Post: /api/Orders
        public async Task<ActionResult<OrderToReturnDto>> CreateOrder(OrderToCreateDto orderDto)
        {
            var buyerEmail = User.FindFirstValue(ClaimTypes.Email); 
            var orders = await serviceManager.OrderService.CreateOrderAsync(buyerEmail!, orderDto);
            return Ok(orders);
        }


        [HttpGet("{id}")] //Get: /api/orders/{id}
        public async Task<ActionResult<OrderToReturnDto>> GetOrder(int id)
        {
            var buyerEmail = User.FindFirstValue(ClaimTypes.Email);
            var order = await serviceManager.OrderService.GetOrderByIdAsync(buyerEmail!, id);
            return Ok(order);
        }


        [HttpGet] //Get: /api/orders
        public async Task<ActionResult<IEnumerable<OrderToReturnDto>>> GetOrdersForUser()
        {
            var buyerEmail = User.FindFirstValue(ClaimTypes.Email);

            var orders = await serviceManager.OrderService.GetOrdersForUserAsync(buyerEmail!);
            return Ok(orders);
        }


        [HttpGet("delivery")] //Get: /api/orders/delivery
        public async Task<ActionResult<IEnumerable<DeliveryMethodDto>>> GetDeliveryMethods()
        {
            var orders = await serviceManager.OrderService.GetDeliveryMethodsAsync();
            return Ok(orders);
        }

    }
}
