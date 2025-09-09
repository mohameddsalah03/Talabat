using System.ComponentModel.DataAnnotations;

namespace Talabat.Core.Application.Abstraction.ModelsDtos.Basket
{
    public class CustomerBasketDto
    {
        public required string Id { get; set; }
        public List<BasketItemDto> Items { get; set; } = new List<BasketItemDto>();

        public string? PaymentIntentId { get; set; }
        public string? ClientSecret { get; set; }
        public int? DeliveryMethodId { get; set; }
        public decimal ShippingPrice { get; set; }

    }
}
