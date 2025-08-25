using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Talabat.Core.Domain.Common;

namespace Talabat.Infrastructure.Persistence.Data.Config.Base
{
    public class BaseEntityConfigurations <TEntity, TKey> : IEntityTypeConfiguration<TEntity>
        where TEntity : BaseEntity<TKey>
        where TKey : IEquatable<TKey>
    { 

        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property(E => E.Id)
                   .ValueGeneratedOnAdd();
        }
    }
}
