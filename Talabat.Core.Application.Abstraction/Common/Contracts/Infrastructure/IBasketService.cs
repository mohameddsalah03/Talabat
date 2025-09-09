using Talabat.Shared.DTOs.Basket;

namespace Talabat.Core.Application.Abstraction.Common.Contracts.Infrastructure
{
    public interface IBasketService
    {
        Task<CustomerBasketDto?> GetCustomerBasketAsync(string basketId);

        Task<CustomerBasketDto?> UpdateCustomerBasketAsync(CustomerBasketDto basketDto/*, TimeSpan timeToLive*/);

        Task DeleteCustomerBasketAsync(string basketId);

    }
}
