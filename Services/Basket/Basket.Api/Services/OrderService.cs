using Basket.Api.Entities;
using Basket.Api.Repositories;

namespace Basket.Api.Services
{
    public class OrderService : IOrderService
    {
        #region Constructor
        private readonly IOrderRepository _orderRepository;
        private readonly IDiscountGrpcService _discountGrpcService;
        public OrderService(IOrderRepository orderRepository, IDiscountGrpcService discountGrpcService)
        {
            _orderRepository = orderRepository;
            _discountGrpcService = discountGrpcService;
        }
        #endregion Constructor

        //***************** GetUserBasket ******************
        public async Task<Order> GetUserBasket(string userName)
            => await _orderRepository.GetAsync(userName);

        //****************** AddOrUpdate *******************
        public async Task<Order> AddOrUpdateUserBasket(Order request)
        {
            await SetDiscount(request);
            await _orderRepository.AddOrUpdateAsync(request);
            return await this.GetUserBasket(request.UserName);
        }

        //***************** DeleteUserBasket ****************
        public async Task DeleteUserBasket(string userName)
            => await _orderRepository.DeleteAsync(userName);

        //*********************************
        private async Task SetDiscount(Order request)
        {
            foreach (var item in request.OrderDetails)
            {
                var coupon = await _discountGrpcService.GetDiscount(item.ProductId);
                item.Price -= coupon.Amount;
            }
        }
    }
}
