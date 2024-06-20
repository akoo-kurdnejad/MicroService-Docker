using Ordering.ApplicationService.CQRS.Orders.Commands.Delete;
using Ordering.ApplicationService.Exceptions;
using Ordering.Domain.Aggregates.OrderAggregate;
using Ordering.Domain.Repositories;

namespace Ordering.ApplicationService.CQRS.Orders.CommandHandlers
{
    internal class DeleteOrderCommandHandler : MediatR.IRequestHandler<DeleteOrderCommand, bool>
    {
        #region Constructor
        private readonly IOrderRepository _orderRepository;

        public DeleteOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        #endregion Constructor

        public async Task<bool> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var orderForDelete = await _orderRepository.GetByIdAsync(request.Id, cancellationToken);
            if (orderForDelete is null)
                throw new NotFoundException(nameof(Order), request.Id);

            _orderRepository.Delete(orderForDelete);
            await _orderRepository.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
