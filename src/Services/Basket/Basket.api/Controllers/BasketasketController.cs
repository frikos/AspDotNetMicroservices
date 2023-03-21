using Basket.api.Entities;
using Basket.api.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Basket.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketasketController : ControllerBase
    {
        private readonly IBasketRepository _basketRepository;

        public BasketasketController(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }

        [HttpGet("{userName}",Name ="GetBasket")]
        [ProducesResponseType(typeof(ShopingCart), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ShopingCart>> GetBasket(string userName)
        {
            var basket = await _basketRepository.GetBasket(userName);
            return Ok(basket ?? new ShopingCart(userName));

        }
        [HttpPost]
        [ProducesResponseType(typeof(ShopingCart), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ShopingCart>> UpdateBasket([FromBody] ShopingCart basket)
        {
            return Ok(await _basketRepository.UpdateBasket(basket));
        }

        [HttpPost("{userName}",Name ="DeleteBasket")]
        [ProducesResponseType(typeof(void), (int)(HttpStatusCode.OK))]
        public async Task<ActionResult<ShopingCart>> DeleteBasket(string userName)
        {
            await _basketRepository.DeleteBasket(userName);
            return Ok();
        }
    }
}
