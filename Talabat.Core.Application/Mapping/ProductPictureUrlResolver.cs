using AutoMapper;
using Microsoft.Extensions.Configuration;
using Talabat.Core.Domain.Entites.Products;
using Talabat.Shared.DTOs.Products;

namespace Talabat.Core.Application.Mapping
{
    public class ProductPictureUrlResolver(IConfiguration configuration) : IValueResolver<Product, ProductToReturnDto, string?>
    {
        public string? Resolve(Product source, ProductToReturnDto destination, string? destMember, ResolutionContext context)
        {
            if(!string.IsNullOrEmpty(source.PictureUrl))
            {
                return $"{configuration["Urls:ApiBaseUrl"]}/{source.PictureUrl}";
            }

            return string.Empty;    
        }
    }
}
