using AutoMapper;
using Talabat.Core.Application.Abstraction.Dtos.Products;
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

        }
    }
}
