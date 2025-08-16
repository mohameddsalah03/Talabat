using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Talabat.Core.Domain.Entites.Products;
using Talabat.Infrastructure.Persistence.Data.Config.Base;

namespace Talabat.Infrastructure.Persistence.Data.Config.Products
{
    public class CategoryConfigurations : BaseEntityConfigurations<ProductCategory , int>
    {
        public override void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            base.Configure(builder);

            builder.Property(B => B.Name)
                .IsRequired();
        }
    }
}
