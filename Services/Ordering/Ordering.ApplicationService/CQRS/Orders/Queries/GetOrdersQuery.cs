using Ordering.ApplicationService.ViewModels;

namespace Ordering.ApplicationService.CQRS.Orders.Queries
{
    public class GetOrdersQuery : MediatR.IRequest<List<OrdersVM>>
    {
        public string UserName { get; set; }

        public GetOrdersQuery(string userName)
        {
            UserName = userName;
        }
    }
}
