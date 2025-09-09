using Talabat.Core.Domain.Entites.Orders;

namespace Talabat.Core.Domain.Specifications.Orders
{
    public class OrderWithPaymentIntentSoecifications : BaseSpecifications<Order, int>
    {

        // This For OrderPaymentId
        public OrderWithPaymentIntentSoecifications(string paymentIntentId)
            : base(order => order.PaymentIntentId == paymentIntentId)
        {


        }
    }
}
