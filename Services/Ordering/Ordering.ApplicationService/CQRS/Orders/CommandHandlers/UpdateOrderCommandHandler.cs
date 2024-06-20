using AutoMapper;
using MediatR;
using Ordering.ApplicationService.CQRS.Orders.Commands.Update;
using Ordering.ApplicationService.Exceptions;
using Ordering.ApplicationService.Models.DTOs;
using Ordering.Domain.Aggregates.OrderAggregate;
using Ordering.Domain.Repositories;

namespace Ordering.ApplicationService.CQRS.Orders.CommandHandlers
{
    internal class UpdateOrderCommandHandler : MediatR.IRequestHandler<UpdateOrderCommand>
    {
        #region Constructor
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public UpdateOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }
        #endregion Constructor

        public async Task<Unit> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var orderForUpdate = await _orderRepository.GetByIdAsync(request.UpdateOrder.Id, cancellationToken);
            if (orderForUpdate is null)
                throw new NotFoundException(nameof(Order), request.UpdateOrder.Id);

            _mapper.Map(request.UpdateOrder, orderForUpdate, typeof(UpdateOrderDTO), typeof(Order));
            _orderRepository.Update(orderForUpdate);
            await _orderRepository.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
