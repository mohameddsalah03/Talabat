namespace Talabat.Core.Domain.Entites.Basket
{
    public class CustomerBasket
    {
        public string Id { get; set; }
        public IEnumerable<BasketItem> Items { get; set; } = new List<BasketItem>();
    }
}
