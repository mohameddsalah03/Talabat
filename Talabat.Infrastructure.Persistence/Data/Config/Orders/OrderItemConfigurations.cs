using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Talabat.Core.Domain.Entites.Orders;
using Talabat.Infrastructure.Persistence.Data.Config.Base;

namespace Talabat.Infrastructure.Persistence.Data.Config.Orders
{
    public class OrderItemConfigurations : BaseAudiatbleEntityConfigurations<OrderItem,int>
    {
        public override void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            base.Configure(builder);

            builder.OwnsOne(Item => Item.Product, product => product.WithOwner());
                   

            builder.Property(Item => Item.Price)
               .HasColumnType("decimal(8,2)");
        }
    }
}
