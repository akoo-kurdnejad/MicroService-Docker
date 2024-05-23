using Basket.Api.Entities;

namespace Basket.Api.Services
{
    public interface IOrderService
    {
        Task<Order> GetUserBasket(string userName);

        Task<Order>AddOrUpdateUserBasket(Order request);

        Task DeleteUserBasket(string userName);
    }
}
