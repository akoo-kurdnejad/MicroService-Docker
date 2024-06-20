using FluentValidation;

namespace Ordering.ApplicationService.CQRS.Orders.Commands.Checkout
{
    public class CheckoutOrderCommandValidator : AbstractValidator<CheckoutOrderCommand>
    {
        public CheckoutOrderCommandValidator()
        {
            RuleFor(current => current.CheckoutOrder.UserName)
                .NotNull()
                .NotEmpty()
                .WithMessage((_) => "یوزر نیم اجباری میباشد");
        }
    }
}
