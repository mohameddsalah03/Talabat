using Talabat.Core.Application.Abstraction.ModelsDtos.Orders;

namespace Talabat.Core.Application.Abstraction.Services.Orders
{
    public interface IOrderService
    {
        Task<OrderToReturnDto> CreateOrderAsync(string byuerEmail, OrderToCreateDto orderDto);
        Task<OrderToReturnDto> GetOrderByIdAsync(string byuerEmail, int orderId);
        Task<IEnumerable<OrderToReturnDto>> GetOrdersForUserAsync(string byuerEmail);
        Task<IEnumerable<DeliveryMethodDto>> GetDeliveryMethodsAsync();


    }
}
