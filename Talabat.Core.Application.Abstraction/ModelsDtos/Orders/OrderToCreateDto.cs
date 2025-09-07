
using Talabat.Core.Application.Abstraction.Common;

namespace Talabat.Core.Application.Abstraction.ModelsDtos.Orders
{
    public class OrderToCreateDto
    {
        public required string BasketId { get; set; }

        public int DeliveryMethodId { get; set; }
        public required AddressDto  ShippingAddress { get; set; }


    }
}
