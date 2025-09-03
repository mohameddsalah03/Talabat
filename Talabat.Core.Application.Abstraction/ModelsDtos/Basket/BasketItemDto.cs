using System.ComponentModel.DataAnnotations;

namespace Talabat.Core.Application.Abstraction.ModelsDtos.Basket
{
    public class BasketItemDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public required string ProductName { get; set; }

        [Required]
        [Range(1, int.MaxValue ,ErrorMessage = "Quantity Must Be At Least One Item.")]
        public int Quantity { get; set; }

        [Required]
        [Range(.1, double.MaxValue, ErrorMessage = "Price Must Be Greater Than Zero.")]
        public decimal Price { get; set; }

        public string? PictureUrl { get; set; }
        public string? Brand { get; set; }
        public string? Category { get; set; }
    }
}
