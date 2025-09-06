using AutoMapper;
using Microsoft.Extensions.Configuration;
using Talabat.Core.Application.Abstraction.ModelsDtos.Orders;
using Talabat.Core.Application.Abstraction.ModelsDtos.Products;
using Talabat.Core.Domain.Entites.Orders;
using Talabat.Core.Domain.Entites.Products;

namespace Talabat.Core.Application.Mapping
{
    public class OrderItemPictureUrlResolver(IConfiguration configuration) : IValueResolver<OrderItem, OrderItemDto, string>
    {
        public string Resolve(OrderItem source, OrderItemDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.Product.PictureUrl))
            {
                return $"{configuration["Urls:ApiBaseUrl"]}/{source.Product.PictureUrl}";
            }

            return string.Empty;
        }
    }
}