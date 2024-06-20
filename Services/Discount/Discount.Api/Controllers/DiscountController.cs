using Discount.Api.Entities;
using Discount.Api.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Discount.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        #region Constructor
        private readonly IDiscountRepository _discountRepository;

        public DiscountController(IDiscountRepository discountRepository)
        {
            _discountRepository = discountRepository;
        }
        #endregion Constructor

        #region Actions

        [HttpGet("{productId}", Name = nameof(GetDiscount))]
        public async Task<IActionResult> GetDiscount(string productId)
        {
            var result = await _discountRepository.GetByProductId(productId);
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Coupon), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateDiscount(Coupon request)
        {
            await _discountRepository.Create(request);
            return CreatedAtRoute(nameof(GetDiscount), new { productId = request.ProductId }, request);
        }

        [HttpPut]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateDiscount(Coupon request)
        {
            var result = await _discountRepository.Update(request);
            return Ok(result);
        }

        [HttpDelete("{productId}")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteDiscount(string productId)
        {
            var result = await _discountRepository.Delete(productId);
            return Ok(result);
        }
        #endregion Actions
    }
}
