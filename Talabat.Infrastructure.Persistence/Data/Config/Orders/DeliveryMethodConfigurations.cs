using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Talabat.Core.Domain.Entites.Orders;
using Talabat.Infrastructure.Persistence.Data.Config.Base;

namespace Talabat.Infrastructure.Persistence.Data.Config.Orders
{
    public class DeliveryMethodConfigurations : BaseEntityConfigurations<DeliveryMethod,int> 
    {
        public override void Configure(EntityTypeBuilder<DeliveryMethod> builder)
        {
            base.Configure(builder);

            builder.Property(D=>D.Cost)
                .HasColumnType("decimal(8,2)");

        }
    }
}
