﻿namespace Talabat.Core.Domain.Entites.Orders
{
    public class OrderAddress : BaseEntity<int>
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Street { get; set; }
        public required string City { get; set; }
        public required string Country { get; set; }

    }
}
