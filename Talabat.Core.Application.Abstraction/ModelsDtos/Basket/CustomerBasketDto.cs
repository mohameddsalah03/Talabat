using System.ComponentModel.DataAnnotations;

namespace Talabat.Core.Application.Abstraction.ModelsDtos.Basket
{
    public class CustomerBasketDto
    {
        [Required]
        public required string Id { get; set; }
        public IEnumerable<BasketItemDto> Items { get; set; } = new List<BasketItemDto>();
    }
}
