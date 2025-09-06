﻿namespace Talabat.Core.Application.Abstraction.ModelsDtos.Orders
{
    public class OrderItemDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public required string ProductName { get; set; }
        public required string PictureUrl { get; set; } 
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}