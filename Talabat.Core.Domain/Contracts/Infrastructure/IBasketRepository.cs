﻿using Talabat.Core.Domain.Entites.Basket;

namespace Talabat.Core.Domain.Contracts.Infrastructure
{
    public interface IBasketRepository
    {
        Task<CustomerBasket?> GetAsync(string id);

        Task<CustomerBasket?> UpdateAsync(CustomerBasket basket, TimeSpan timeToLive);

        Task<bool> DeleteAsync(string id);



    }
}
