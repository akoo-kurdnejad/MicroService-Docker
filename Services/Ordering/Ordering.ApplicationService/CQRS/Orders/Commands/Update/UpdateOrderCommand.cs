using Ordering.ApplicationService.Models.DTOs;

namespace Ordering.ApplicationService.CQRS.Orders.Commands.Update
{
    public class UpdateOrderCommand : MediatR.IRequest
    {
        public UpdateOrderDTO UpdateOrder { get; private set; }

        public UpdateOrderCommand(UpdateOrderDTO updateOrder)
        {
            UpdateOrder = updateOrder;
        }
    }
}
