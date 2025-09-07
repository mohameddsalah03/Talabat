namespace Talabat.Core.Domain.Entites.Orders
{
    public class Order : BaseAuditableEntity<int>
    {
        public required string BuyerEmail { get; set; } 
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        public required OrderAddress ShippingAddress { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
      
        
        // => DeliveryMethod is a Realtion With Order [1:m]
        public virtual DeliveryMethod? DeliveryMethod { get; set; } 
        public int? DeliveryMethodId { get; set; }


        public virtual ICollection<OrderItem> Items { get; set; }= new HashSet<OrderItem>();

        // [Derived Attribute] 
        public decimal SubTotal { get; set; }
        public decimal GetTotal() => SubTotal + DeliveryMethod!.Cost;

        public string PaymentIntentId { get; set; } = "";

    }
}
