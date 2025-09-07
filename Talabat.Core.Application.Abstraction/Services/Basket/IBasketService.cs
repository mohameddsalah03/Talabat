using Talabat.Core.Application.Abstraction.ModelsDtos.Basket;

namespace Talabat.Core.Application.Abstraction.Services.Basket
{
    public interface IBasketService
    {
        Task<CustomerBasketDto?> GetCustomerBasketAsync(string basketId);

        Task<CustomerBasketDto?> UpdateCustomerBasketAsync(CustomerBasketDto basketDto/*, TimeSpan timeToLive*/);

        Task DeleteCustomerBasketAsync(string basketId);

    }
}
