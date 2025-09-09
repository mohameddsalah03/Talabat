using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Stripe;
using Stripe.Forwarding;
using Talabat.Core.Application.Abstraction.ModelsDtos.Basket;
using Talabat.Core.Application.Exceptions;
using Talabat.Core.Domain.Contracts;
using Talabat.Core.Domain.Contracts.Infrastructure;
using Talabat.Core.Domain.Entites.Basket;
using Talabat.Core.Domain.Entites.Orders;
using Talabat.Core.Domain.Specifications.Orders;
using Talabat.Shared.Models;
using Product = Talabat.Core.Domain.Entites.Products.Product;

namespace Talabat.Infrastructure.PaymentServices
{
   
    internal class PaymentService(
        IBasketRepository basketRepository,
        IUnitOfWork unitOfWork,
        IOptions<RedisSettings> redisSettings,
        IOptions<StripeSettings> stripeSettings,
        IMapper mapper,
        ILogger<PaymentService> logger
        ) : IPaymentService
    {

        private readonly RedisSettings _redisSettings = redisSettings.Value;
        private readonly StripeSettings _stripeSettings = stripeSettings.Value;

        public async Task<CustomerBasketDto> CreateOrUpdatePaymentIntent(string basketId)
        {

            // To Confirm for stripe acconut
            StripeConfiguration.ApiKey = _stripeSettings.SecretKey;

            var basket = await basketRepository.GetAsync(basketId);
            if (basket is null) throw new NotFoundException(nameof(CustomerBasket), basketId);

            if (basket.DeliveryMethodId.HasValue)
            {
                var deliveryMethod = await unitOfWork.GetRepository<DeliveryMethod, int>().GetAsync(basket.DeliveryMethodId.Value);
                if (deliveryMethod is null) throw new NotFoundException(nameof(deliveryMethod), basket.DeliveryMethodId.Value);

                basket.ShippingPrice = deliveryMethod!.Cost;
            }

            if (basket.Items.Count > 0)
            {
                var productRepo = unitOfWork.GetRepository<Product, int>();
                foreach (var item in basket.Items)
                {
                    var product = await productRepo.GetAsync(item.Id);
                    if (product is null) throw new NotFoundException(nameof(Product), item.Id);

                    if (item.Price != product!.Price)
                        item.Price = product.Price;

                }
            }

            PaymentIntent paymentIntent = null!;
            var PaymentService = new PaymentIntentService();
            if (string.IsNullOrEmpty(basket.PaymentIntentId)) // Create New PaymentIntent
            {
                var options = new PaymentIntentCreateOptions()
                {
                    Amount = (long)basket.Items.Sum(item => item.Price * 100 * item.Quantity) + (long)basket.ShippingPrice * 100,
                    Currency = "USD",
                    PaymentMethodTypes = new List<string>() { "card" }
                };
                paymentIntent = await PaymentService.CreateAsync(options);
                basket.PaymentIntentId = paymentIntent.Id;
                basket.ClientSecret = paymentIntent.ClientSecret;
            }
            else // Update An Existing PaymentIntent
            {
                var Options = new PaymentIntentUpdateOptions()
                {
                    Amount = (long)basket.Items.Sum(item => item.Price * 100 * item.Quantity) + (long)basket.ShippingPrice * 100,
                };
                await PaymentService.UpdateAsync(basket.PaymentIntentId, Options);
            }

            await basketRepository.UpdateAsync(basket, TimeSpan.FromDays(_redisSettings.TimeToLiveInDays));

            return mapper.Map<CustomerBasketDto>(basket);
        }

        public async Task UpdateOrderPaymentStatus(string requestBody, string header)
        {
            string _whSecret =  _stripeSettings.WebhookSecret;
            var stripeEvent = EventUtility.ConstructEvent(requestBody,header, _whSecret);


            var paymentIntent = (PaymentIntent)stripeEvent.Data.Object;
            Order? order;
            switch (stripeEvent.Type)
            {
                case "payment_intent.succeeded":
                    order = await UpdatePaymentIntent(paymentIntent.Id, true);
                    logger.LogInformation("Order Is Succeeded With Payment IntentId:{0} ", paymentIntent.Id);
                    break;

                case "payment_intent.payment_failed":
                    order = await UpdatePaymentIntent(paymentIntent.Id , false);
                    logger.LogInformation("Order Is Not Succeeded With Payment IntentId:{0} ", paymentIntent.Id);

                    break;
            }
        }

        private async Task<Order> UpdatePaymentIntent(string paymentIntentId, bool isPaid)
        {
            var orderRepo = unitOfWork.GetRepository<Order, int>();
            var spec = new OrderWithPaymentIntentSoecifications(paymentIntentId);
            var order = await orderRepo.GetWithSpecAsync(spec);

            if (order is null) throw new NotFoundException(nameof(Order), $"PaymentIntentId: {paymentIntentId}");

            if(isPaid)
                order.Status = OrderStatus.PaymentReceived;
            else
                order.Status = OrderStatus.PaymentFailed;


            orderRepo.Update(order);
            await unitOfWork.CompleteAsync();

            return order;
        }
    }

}
