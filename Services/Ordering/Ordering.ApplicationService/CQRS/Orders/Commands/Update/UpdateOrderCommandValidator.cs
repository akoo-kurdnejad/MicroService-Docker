using FluentValidation;

namespace Ordering.ApplicationService.CQRS.Orders.Commands.Update
{
    public class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
    {
        public UpdateOrderCommandValidator()
        {
            RuleFor(current => current.UpdateOrder.Id)
                .GreaterThan(0)
                .WithMessage("id is requird");
        }
    }
}
