using MultiShop.Basket.Dtos;
using MultiShop.Basket.Settings;
using System.Text.Json;

namespace MultiShop.Basket.Services
{
    public class BasketService : IBasketService
    {
        private readonly RedisService _redisservice;

        public BasketService(RedisService redisservice)
        {
            _redisservice = redisservice;
        }

        public async Task DeleteBasket(string userId)
        {
            await _redisservice.GetDb().KeyDeleteAsync(userId);
        }

        public async Task<BasketTotalDto> GetBasket(string userId)
        {
            var existBasket = await _redisservice.GetDb().StringGetAsync(userId);

            if (!existBasket.HasValue)
            {
                return null;
            }

            return JsonSerializer.Deserialize<BasketTotalDto>((string)existBasket);
        }

        public async Task SaveBasket(BasketTotalDto basketTotalDto)
        {
            await _redisservice.GetDb().StringSetAsync(basketTotalDto.UserId, JsonSerializer.Serialize(basketTotalDto));
        }
    }
}
