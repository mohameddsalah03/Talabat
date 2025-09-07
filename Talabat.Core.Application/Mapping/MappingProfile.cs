using AutoMapper;
using Talabat.Core.Application.Abstraction.Common;
using Talabat.Core.Application.Abstraction.ModelsDtos.Basket;
using Talabat.Core.Application.Abstraction.ModelsDtos.Orders;
using Talabat.Core.Application.Abstraction.ModelsDtos.Products;
using Talabat.Core.Domain.Entites.Basket;
using Talabat.Core.Domain.Entites.Identity;
using Talabat.Core.Domain.Entites.Orders;
using Talabat.Core.Domain.Entites.Products;

namespace Talabat.Core.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductToReturnDto>()
                .ForMember(d => d.Brand, options => options.MapFrom(src => src.Brand!.Name))
                .ForMember(d => d.Category, options => options.MapFrom(src => src.Category!.Name))
                // For PictureUrl
                .ForMember(d => d.PictureUrl, options => options.MapFrom<ProductPictureUrlResolver>());


            CreateMap<ProductBrand, BrandDto>();
            CreateMap<ProductCategory, CategoryDto>();

            
            //for Basket
            CreateMap<CustomerBasket,CustomerBasketDto>().ReverseMap();
            CreateMap<BasketItem,BasketItemDto>().ReverseMap();


            //for Orders
            CreateMap<Order, OrderToReturnDto>()
               .ForMember(d => d.DeliveryMethod, options => options.MapFrom(src => src.DeliveryMethod!.ShortName));
            //
            CreateMap<OrderItem, OrderItemDto>()
              .ForMember(d => d.ProductId, options => options.MapFrom(src => src.Product.ProductId))
              .ForMember(d => d.ProductName, options => options.MapFrom(src => src.Product.ProductName))
              .ForMember(d => d.PictureUrl, options => options.MapFrom<OrderItemPictureUrlResolver>());
            //
            CreateMap<DeliveryMethod, DeliveryMethodDto>();

            // mapping address for order
            CreateMap<OrderAddress, AddressDto>().ReverseMap();
            
            
            // mapping address for user
            CreateMap<Address, AddressDto>().ReverseMap();

            

        }
    }
}
