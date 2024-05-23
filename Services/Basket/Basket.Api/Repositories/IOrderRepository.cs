using Basket.Api.Entities;

namespace Basket.Api.Repositories
{
    public interface IOrderRepository
    {
        Task<Order> GetAsync(string userName);

        Task AddOrUpdateAsync(Order order);

        Task DeleteAsync(string userName);
    }
}
