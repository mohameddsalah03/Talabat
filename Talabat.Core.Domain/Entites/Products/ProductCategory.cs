
namespace Talabat.Core.Domain.Entites.Products
{
    public class ProductCategory : BaseAuditableEntity<int>
    {
        public required string Name { get; set; }
    }
}
