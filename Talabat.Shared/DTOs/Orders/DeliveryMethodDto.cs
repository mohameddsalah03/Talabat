﻿namespace Talabat.Shared.DTOs.Orders
{
    public class DeliveryMethodDto
    {
        public int Id { get; set; }
        public required string ShortName { get; set; }
        public required string Description { get; set; }
        public required string DeliveryTime { get; set; }
        public decimal Cost { get; set; }
    }
}
