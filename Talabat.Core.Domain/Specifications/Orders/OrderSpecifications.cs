using Talabat.Core.Domain.Entites.Orders;

namespace Talabat.Core.Domain.Specifications.Orders
{
    public class OrderSpecifications : BaseSpecifications<Order, int>
    {
        public OrderSpecifications(string buyerEmail)
            : base(order => order.BuyerEmail == buyerEmail)
        {
            AddIncludes();
            AddOrderByDesc(order => order.OrderDate);
        }

        // This For GetOrderByIdAsync
        public OrderSpecifications(string buyerEmail, int orderId)
            : base(order => order.BuyerEmail == buyerEmail && order.Id == orderId)
        {
            AddIncludes();
            
        }


        
        private protected override void AddIncludes()
        {
            base.AddIncludes();
            Includes.Add(O => O.DeliveryMethod!);
            Includes.Add(O => O.Items);
        }


    }
}
