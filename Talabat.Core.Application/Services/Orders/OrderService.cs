using AutoMapper;
using Talabat.Core.Application.Abstraction.ModelsDtos.Orders;
using Talabat.Core.Application.Abstraction.Services.Basket;
using Talabat.Core.Application.Abstraction.Services.Orders;
using Talabat.Core.Application.Exceptions;
using Talabat.Core.Domain.Contracts;
using Talabat.Core.Domain.Entites.Orders;
using Talabat.Core.Domain.Entites.Products;
using Talabat.Core.Domain.Specifications.Orders;

namespace Talabat.Core.Application.Services.Orders
{
    public class OrderService(IUnitOfWork _unitOfWork, IMapper _mapper, IBasketService _basketService) : IOrderService
    {
        public async Task<OrderToReturnDto> CreateOrderAsync(string byuerEmail, OrderToCreateDto orderDto)
        {
            //Get Basket from basket service
            var basket = await _basketService.GetCustomerBasketAsync(orderDto.BasketId); //  not needed to check if basket is null [checking in GetCustomerBasketAsync already]

            // 2. orderItem Include ProductItmeOrder
            var orderItems = new List<OrderItem>();
            if(basket!.Items.Count() > 0)
            {
                // Product Repo
                var productRepo = _unitOfWork.GetRepository<Product,int>();

                foreach(var item in basket.Items)
                {
                    var product = await productRepo.GetAsync(item.Id);
                    if(product != null)
                    {
                        
                        //OrderItem
                        var orderItem = new OrderItem()
                        {
                            Product = new ProductItemOrdered()
                            {
                                ProductId = product.Id,
                                ProductName = product.Name,
                                PictureUrl = product.PictureUrl ?? ""
                            },
                            Price = product.Price,
                            Quantity = item.Quantity,
                        };
                        orderItems.Add(orderItem);
                    }

                }

            }

            // 3.calculatee subTotal
            var subTotal = orderItems.Sum(item => item.Price * item.Quantity);

            // 4. Map Address
            var addressMapped = _mapper.Map<OrderAddress>(orderDto.ShippingAddress);

            // 5.Get DeliveryMethod
            var deliveryMethod = await _unitOfWork.GetRepository<DeliveryMethod,int>().GetAsync(orderDto.DeliveryMethodId);

            // 6.create Order
            var OrderToCreate = new Order()
            {
                BuyerEmail = byuerEmail,
                ShippingAddress = addressMapped,
                Items = orderItems,
                DeliveryMethod = deliveryMethod,
                SubTotal = subTotal,
            };
            
            await _unitOfWork.GetRepository<Order,int>().AddAsync(OrderToCreate);

            // 7. save to database
            var created = await _unitOfWork.CompleteAsync() > 0;
            if (!created) throw new BadRequestException("An error Ocuured During Created ORder");
            
            return _mapper.Map<OrderToReturnDto>(OrderToCreate);
        }
        public async Task<IEnumerable<OrderToReturnDto>> GetOrdersForUserAsync(string byuerEmail)
        {
            var spec = new OrderSpecifications(byuerEmail);
            var orders = await _unitOfWork.GetRepository<Order, int>().GetAllWithSpecAsync(spec);
            var data = _mapper.Map<IEnumerable<OrderToReturnDto>>(orders);
            return data;
        }

        public async Task<OrderToReturnDto> GetOrderByIdAsync(string byuerEmail, int orderId)
        {
            var spec = new OrderSpecifications(byuerEmail , orderId);
            var order = await _unitOfWork.GetRepository<Order, int>().GetWithSpecAsync(spec);
            if(order is null) throw new NotFoundException(nameof(Order),orderId);
            var data = _mapper.Map<OrderToReturnDto>(order);
            return data;
        }

        public async Task<IEnumerable<DeliveryMethodDto>> GetDeliveryMethodsAsync()
        {
            var deliveries = await _unitOfWork.GetRepository<DeliveryMethod, int>().GetAllAsync();
            var data = _mapper.Map<IEnumerable<DeliveryMethodDto>>(deliveries);
            return data;
        }

    }
}
