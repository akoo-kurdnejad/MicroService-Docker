using Basket.Api.Entities;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace Basket.Api.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        #region Constructor
        private readonly IDistributedCache _redisCache;

        public OrderRepository(IDistributedCache redisCache)
        {
            _redisCache = redisCache;
        }
        #endregion Constructor

        //############### GetAsync ##################
        public async Task<Order> GetAsync(string userName)
        {
            var basket = await _redisCache.GetStringAsync(userName);
            if (string.IsNullOrWhiteSpace(basket)) return null;
            return JsonConvert.DeserializeObject<Order>(basket);
        }

        //############### AddOrUpdateAsync ##################
        public async Task AddOrUpdateAsync(Order order)
            => await _redisCache.SetStringAsync(order.UserName, JsonConvert.SerializeObject(order));

        //############### DeleteAsync ##################
        public async Task DeleteAsync(string userName)
            => await _redisCache.RemoveAsync(userName);
    }
}
