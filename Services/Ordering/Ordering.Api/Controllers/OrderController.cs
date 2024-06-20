using MediatR;
using Microsoft.AspNetCore.Mvc;
using Ordering.ApplicationService.CQRS.Orders.Commands.Checkout;
using Ordering.ApplicationService.CQRS.Orders.Commands.Delete;
using Ordering.ApplicationService.CQRS.Orders.Commands.Update;
using Ordering.ApplicationService.CQRS.Orders.Queries;
using Ordering.ApplicationService.ViewModels;
using System.Net;

namespace Ordering.Api.Controllers
{
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        #region Constructor
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }
        #endregion Constructor

        #region Commands
        [HttpGet("{userName}", Name = "GetOrders")]
        [ProducesResponseType(typeof(IEnumerable<OrdersVM>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetOrderByUserName(string userName, CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetOrdersQuery(userName), cancellationToken);
            return Ok(result);
        }

        [HttpPost(Name = "CheckoutOrder")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CheckoutOrder([FromBody] CheckoutOrderCommand request,  CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(request, cancellationToken);
            return Ok(result);
        }

        [HttpPut(Name = "UpdateOrder")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateOrder([FromBody] UpdateOrderCommand request, CancellationToken cancellationToken = default)
        {
            await _mediator.Send(request, cancellationToken);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteOrder")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteOrder(int id)
        {
            await _mediator.Send(new DeleteOrderCommand(id));
            return NoContent();
        }
        #endregion Commands
    }
}
