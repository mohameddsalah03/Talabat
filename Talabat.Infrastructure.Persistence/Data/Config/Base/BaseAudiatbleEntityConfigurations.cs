using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Talabat.Core.Domain.Common;

namespace Talabat.Infrastructure.Persistence.Data.Config.Base
{
    public class BaseAudiatbleEntityConfigurations<TEntity, TKey> : BaseEntityConfigurations<TEntity,TKey>
        where TEntity : BaseAuditableEntity<TKey>
        where TKey : IEquatable<TKey>

    {
        public override void Configure(EntityTypeBuilder<TEntity> builder)
        {
           base.Configure(builder);

            builder.Property(E => E.CreatedBy)
                   .IsRequired();

            builder.Property(E => E.CreatedOn)
                   .IsRequired()
                   /*.HasDefaultValueSql("GETUTCDATE()")*/;

            builder.Property(E => E.LastModifiedBy)
                   .IsRequired();

            builder.Property(E => E.LastModifiedOn)
                   .IsRequired()
                   /*.HasDefaultValueSql("GETUTCDATE()")*/;



        }
    }
}
