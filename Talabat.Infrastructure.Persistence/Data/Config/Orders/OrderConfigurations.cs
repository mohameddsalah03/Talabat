using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Talabat.Core.Domain.Entites.Orders;
using Talabat.Infrastructure.Persistence.Data.Config.Base;

namespace Talabat.Infrastructure.Persistence.Data.Config.Orders
{
    public class OrderConfigurations : BaseAudiatbleEntityConfigurations<Order,int>
    {
        public override void Configure(EntityTypeBuilder<Order> builder)
        {
            base.Configure(builder);

            builder.OwnsOne(order => order.ShippingAddress, shippingAddress => shippingAddress.WithOwner());

            builder.Property(order => order.Status)
                .HasConversion
                (
                    (OStatus) => OStatus.ToString(),
                    (OStatus) => (OrderStatus)Enum.Parse(typeof(OrderStatus), OStatus)
                );

            builder.Property(order => order.SubTotal)
                .HasColumnType("decimal(8,2)");


            //Relations
            builder.HasOne(order=>order.DeliveryMethod)
                .WithMany()
                .HasForeignKey(order => order.DeliveryMethodId)
                .OnDelete(DeleteBehavior.SetNull);


            builder.HasMany(order => order.Items)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
