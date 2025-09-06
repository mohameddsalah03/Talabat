namespace Talabat.Core.Domain.Entites.Orders
{
    public class DeliveryMethod : BaseEntity<int>
    {
        public required string ShortName { get; set; }
        public required string Description { get; set; }
        public required string DeliveryTime { get; set; }
        public decimal Cost { get; set; }
    }
}
