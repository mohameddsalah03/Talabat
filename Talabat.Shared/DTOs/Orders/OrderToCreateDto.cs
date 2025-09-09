﻿using Talabat.Shared.DTOs.Common;

namespace Talabat.Shared.DTOs.Orders
{
    public class OrderToCreateDto
    {
        public required string BasketId { get; set; }

        public int DeliveryMethodId { get; set; }
        public required AddressDto  ShippingAddress { get; set; }


    }
}
