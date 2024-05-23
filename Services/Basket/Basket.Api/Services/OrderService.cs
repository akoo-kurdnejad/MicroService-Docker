using Basket.Api.Entities;
using Basket.Api.Repositories;

namespace Basket.Api.Services
{
    public class OrderService : IOrderService
    {
        #region Constructor
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        #endregion Constructor

        //***************** GetUserBasket ******************
        public async Task<Order> GetUserBasket(string userName)
            => await _orderRepository.GetAsync(userName);

        //****************** AddOrUpdate *******************
        public async Task<Order> AddOrUpdateUserBasket(Order request)
        {
            await _orderRepository.AddOrUpdateAsync(request);
            return await this.GetUserBasket(request.UserName);
        }

        //***************** DeleteUserBasket ****************
        public async Task DeleteUserBasket(string userName)
            => await _orderRepository.DeleteAsync(userName);
    }
}
