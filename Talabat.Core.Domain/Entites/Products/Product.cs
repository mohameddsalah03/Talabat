
namespace Talabat.Core.Domain.Entites.Products
{
    public class Product : BaseEntity<int>
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public string? PictureUrl { get; set; }
        public decimal Price { get; set; }

        
        // Relation With Brand
        public int? BrandId { get; set; } // FK --> ProductBrand Entity
        public virtual ProductBrand? Brand { get; set; } // Virtual To Enable Lazy Mode


        // Relation With Category
        public int? CategoryId { get; set; } // FK --> ProductCategory Entity
        public virtual ProductCategory? Category { get; set; } // Virtual To Enable Lazy Mode


    }
}
