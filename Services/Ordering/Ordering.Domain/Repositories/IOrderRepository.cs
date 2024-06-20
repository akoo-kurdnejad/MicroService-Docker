using Ordering.Domain.Aggregates.OrderAggregate;
using Ordering.Domain.Repositories.Base;

namespace Ordering.Domain.Repositories
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
    }
}
