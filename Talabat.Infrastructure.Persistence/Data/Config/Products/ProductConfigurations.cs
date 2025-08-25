using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Talabat.Core.Domain.Entites.Products;
using Talabat.Infrastructure.Persistence.Data.Config.Base;

namespace Talabat.Infrastructure.Persistence.Data.Config.Products
{
    public class ProductConfigurations : BaseAudiatbleEntityConfigurations<Product,int>
    {
        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            base.Configure(builder);

            builder.Property(P => P.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(P => P.Description)
                .IsRequired();

            builder.Property(P => P.Price)
                .HasColumnType("decimal(9,2)");

            //Relations With Brand
            builder.HasOne(p => p.Brand)
                    .WithMany()
                    .HasForeignKey(p => p.BrandId)
                    .OnDelete(DeleteBehavior.SetNull);
            
            //Relations With Category
            builder.HasOne(p => p.Category)
                    .WithMany()
                    .HasForeignKey(p => p.CategoryId)
                    .OnDelete(DeleteBehavior.SetNull);


        }
    }
}
