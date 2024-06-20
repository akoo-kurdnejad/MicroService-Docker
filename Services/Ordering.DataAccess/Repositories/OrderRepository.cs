using Ordering.DataAccess.EF.DBContext;
using Ordering.DataAccess.Repositories.Base;
using Ordering.Domain.Aggregates.OrderAggregate;
using Ordering.Domain.Repositories;

namespace Ordering.DataAccess.Repositories
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        #region Constructor
        public OrderRepository(OrderingDBContext dbContext) : base(dbContext)
        {
        }
        #endregion Constructor
    }
}
