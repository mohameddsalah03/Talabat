using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Domain.Common;

namespace Talabat.Infrastructure.Persistence.Data.Config.Base
{
    public class BaseEntityConfigurations<TEntity, TKey> : IEntityTypeConfiguration<TEntity>
        where TEntity : BaseEntity<TKey>
        where TKey : IEquatable<TKey>

    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property(E => E.Id)
                .ValueGeneratedOnAdd();

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
