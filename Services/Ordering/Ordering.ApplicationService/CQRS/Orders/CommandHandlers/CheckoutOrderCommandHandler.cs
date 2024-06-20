using AutoMapper;
using Ordering.ApplicationService.CQRS.Orders.Commands.Checkout;
using Ordering.Domain.Aggregates.OrderAggregate;
using Ordering.Domain.Repositories;

namespace Ordering.ApplicationService.CQRS.Orders.CommandHandlers
{
    internal class CheckoutOrderCommandHandler : MediatR.IRequestHandler<CheckoutOrderCommand, int>
    {
        #region Constructor
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public CheckoutOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }
        #endregion Constructor

        public async Task<int> Handle(CheckoutOrderCommand request, CancellationToken cancellationToken)
        {
            var mapper = _mapper.Map<Order>(request.CheckoutOrder);
            var newOrder = await _orderRepository.CreateAsync(mapper, cancellationToken);
            await _orderRepository.SaveChangesAsync(cancellationToken);
            return newOrder.Id;
        }
    }
}
