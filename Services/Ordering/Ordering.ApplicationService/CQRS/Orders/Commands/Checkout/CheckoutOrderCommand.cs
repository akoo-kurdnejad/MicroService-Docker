using Ordering.ApplicationService.Models.DTOs;

namespace Ordering.ApplicationService.CQRS.Orders.Commands.Checkout
{
    public class CheckoutOrderCommand : MediatR.IRequest<int>
    {
        public CheckoutOrderCommand(CheckoutOrderDTO checkoutOrder)
        {
            CheckoutOrder = checkoutOrder;
        }

        public CheckoutOrderDTO CheckoutOrder { get; private set; }
    }
}
