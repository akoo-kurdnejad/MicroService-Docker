using Microsoft.EntityFrameworkCore;
using Ordering.Domain.Aggregates.OrderAggregate;

namespace Ordering.DataAccess.EF.DBContext
{
    public class OrderContextSeed
    {
        public static async Task SeedAsync(OrderingDBContext orderContext)
        {
            if (!await orderContext.Orders.AnyAsync())
            {
                await orderContext.Orders.AddRangeAsync(GetPreconfiguredOrders());
                await orderContext.SaveChangesAsync();
            }
        }

        public static IEnumerable<Order> GetPreconfiguredOrders()
        {
            return new List<Order>
            {
                new Order
                {
                    FirstName = "akoo",
                    LastName = "kurdnejad",
                    UserName = "akoo",
                    EmailAddress = "akoo@yahoo.com",
                    City = "tehran",
                    Country = "iran",
                    TotalPrice = 10000
                }
            };
        }
    }
}
