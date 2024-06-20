using Basket.Api.DTOs;
using Basket.Api.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Basket.Api.Controllers
{
    [Route("api/[action]/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        #region Constructor
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        #endregion Constructor

        #region Actions

        [HttpGet("{userName}", Name = nameof(GetBasket))]
        [ProducesResponseType(typeof(Entities.Order), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetBasket(string userName)
        {
            var result = await _orderService.GetUserBasket(userName);
            return Ok(result ?? new Entities.Order(userName));
        }

        [HttpPost]
        [ProducesResponseType(typeof(Entities.Order), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateBasket([FromBody] Entities.Order request)
        {
            var result = await _orderService.AddOrUpdateUserBasket(request);
            return Ok(result);
        }

        [HttpDelete("{userName}", Name =nameof(DeleteBasket))]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteBasket(string userName)
        {
            await _orderService.DeleteUserBasket(userName);
            return Ok();
        }

        [HttpPost]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Checkout([FromBody] BasketCheckoutDTO request)
        {
            await _orderService.BasketCheckout(request);
            return Ok();
        }
        #endregion Actions
    }
}
