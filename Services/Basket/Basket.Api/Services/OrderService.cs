using AutoMapper;
using Basket.Api.DTOs;
using Basket.Api.Entities;
using Basket.Api.Repositories;
using EventBus.Messages.Events;
using MassTransit;

namespace Basket.Api.Services
{
    public class OrderService : IOrderService
    {
        #region Constructor
        private readonly IOrderRepository _orderRepository;
        private readonly IDiscountGrpcService _discountGrpcService;
        private readonly IMapper _mapper;
        private readonly IPublishEndpoint _publishEndpoint;

        public OrderService(IOrderRepository orderRepository,
                            IDiscountGrpcService discountGrpcService,
                            IMapper mapper,
                            IPublishEndpoint publishEndpoint)
        {
            _orderRepository = orderRepository;
            _discountGrpcService = discountGrpcService;
            _mapper = mapper;
            _publishEndpoint = publishEndpoint;
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

        //***************** BasketCheckout ****************
        public async Task BasketCheckout(BasketCheckoutDTO request)
        {
            var basket = await this.GetUserBasket(request.UserName);
            if (basket is null)
                throw new ArgumentException("not found basket");

            await PublishEvent(request, basket);
            await this.DeleteUserBasket(request.UserName);
        }

        //*********************************
        private async Task PublishEvent(BasketCheckoutDTO request, Order basket)
        {
            var eventMessage = _mapper.Map<BasketCheckoutEvent>(request);
            eventMessage.TotalPrice = basket.TotalPrice;
            await _publishEndpoint.Publish(eventMessage);
        }

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
