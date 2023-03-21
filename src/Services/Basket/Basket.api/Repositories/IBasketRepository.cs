using Basket.api.Entities;

namespace Basket.api.Repositories
{
    public interface IBasketRepository
    {
        Task<ShopingCart> GetBasket(string Username);
        Task<ShopingCart> UpdateBasket(ShopingCart basket);
        Task DeleteBasket(string Username);
    }
}
