namespace Talabat.Core.Application.Abstraction.ModelsDtos.Products
{
    public class ProductToReturnDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public string? PictureUrl { get; set; }
        public decimal Price { get; set; }


        // Relation With Brand
        public int? BrandId { get; set; } 
        public string? Brand { get; set; } 


        // Relation With Category
        public int? CategoryId { get; set; } 
        public  string? Category { get; set; } 

    }
}
