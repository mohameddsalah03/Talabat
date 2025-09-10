using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Talabat.APIs.Controllers.Controllers.Base;
using Talabat.Core.Application.Abstraction.Common.Contracts.Infrastructure;
using Talabat.Shared.DTOs.Basket;

namespace Talabat.APIs.Controllers.Controllers.Payment
{
    public class PaymentController(IPaymentService paymentService) : BaseApiController
    {

        [Authorize]

        [HttpPost("{basketId}")] //POST: /api/payment/{baketId}
        public async Task<ActionResult<CustomerBasketDto>> CreateOrUpdatePaymentIntent(string basketId)
        {
            var result = await paymentService.CreateOrUpdatePaymentIntent(basketId);
            return Ok(result);
        }


        [HttpPost("webhook")]
        public async Task<IActionResult> WebHook()
        {
            var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();

            await paymentService.UpdateOrderPaymentStatus(json, Request.Headers["Stripe-Signature"]!);
            return Ok();
        }
    }
}
