using Talabat.Shared.DTOs.Common;

namespace Talabat.Shared.DTOs.Orders
{
    public class OrderToReturnDto
    {
        public int Id { get; set; }

        public required string BuyerEmail { get; set; }
        public DateTime OrderDate { get; set; } 
        public required AddressDto ShippingAddress { get; set; }
        public required string Status { get; set; } 


        // => DeliveryMethod is a Realtion With Order [1:m]
        public int? DeliveryMethodId { get; set; }
        public string? DeliveryMethod { get; set; }


        public virtual required ICollection<OrderItemDto> Items { get; set; } 

        // [Derived Attribute] 
        public decimal SubTotal { get; set; }
        public decimal Total { get; set; }

        public string PaymentIntentId { get; set; }
    }
}
