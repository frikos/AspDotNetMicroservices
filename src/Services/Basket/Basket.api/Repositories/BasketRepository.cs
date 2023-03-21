using Basket.api.Entities;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace Basket.api.Repositories
{
    public class BasketRepository:IBasketRepository
    {
        private readonly IDistributedCache _redisCache;

        public BasketRepository(IDistributedCache redis)
        {
            _redisCache = redis;
        }

       
        public async Task<ShopingCart> GetBasket(string Username)
        {
            var basket = await _redisCache.GetStringAsync(Username);
            if (string.IsNullOrEmpty(basket)) return null;

            return JsonConvert.DeserializeObject<ShopingCart>(basket);  
        }

        public async Task<ShopingCart> UpdateBasket(ShopingCart basket)
        {
            await _redisCache.SetStringAsync(basket.userName, JsonConvert.SerializeObject(basket));
            return await GetBasket(basket.userName);
            
        }

        public async Task DeleteBasket(string Username)
        {
            await _redisCache.RemoveAsync(Username);
        }

    }
}
