using Talabat.Shared.DTOs.Basket;

namespace Talabat.Core.Application.Abstraction.Common.Contracts.Infrastructure
{
    public interface IPaymentService
    {
        Task<CustomerBasketDto> CreateOrUpdatePaymentIntent(string basketId);
        Task UpdateOrderPaymentStatus(string requestBody, string header);
    }
}
