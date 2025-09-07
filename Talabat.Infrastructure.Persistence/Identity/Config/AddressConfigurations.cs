using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Talabat.Core.Domain.Entites.Identity;
using Talabat.Infrastructure.Persistence.Common;

namespace Talabat.Infrastructure.Persistence.Identity.Config
{

    [DbContextType(typeof(StoreIdentityDbContext))]
    public class AddressConfigurations : IEntityTypeConfiguration<Address>
    {
        
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Addresses");

            builder.Property(nameof(Address.Id)).ValueGeneratedOnAdd();
            builder.Property(nameof(Address.FirstName)).HasColumnType("nvarchar").HasMaxLength(50);
            builder.Property(nameof(Address.LastName)).HasColumnType("nvarchar").HasMaxLength(50);
            builder.Property(nameof(Address.City)).HasColumnType("varchar").HasMaxLength(50);
            builder.Property(nameof(Address.Street)).HasColumnType("varchar").HasMaxLength(50);
            builder.Property(nameof(Address.Country)).HasColumnType("varchar").HasMaxLength(50);

        }
    }
}
