using Talabat.Core.Application.Abstraction.ModelsDtos.Basket;

namespace Talabat.Core.Domain.Contracts.Infrastructure
{
    public interface IPaymentService
    {
        Task<CustomerBasketDto> CreateOrUpdatePaymentIntent(string basketId);
        Task UpdateOrderPaymentStatus(string requestBody, string header);
    }
}
