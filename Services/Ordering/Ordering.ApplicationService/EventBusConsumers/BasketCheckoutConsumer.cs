using AutoMapper;
using EventBus.Messages.Events;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;
using Ordering.ApplicationService.CQRS.Orders.Commands.Checkout;
using Ordering.ApplicationService.Models.DTOs;

namespace Ordering.ApplicationService.EventBusConsumers
{
    public class BasketCheckoutConsumer : IConsumer<BasketCheckoutEvent>
    {
        #region Constructor
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ILogger<BasketCheckoutConsumer> _logger;

        public BasketCheckoutConsumer(IMediator mediator, 
                                      IMapper mapper, 
                                      ILogger<BasketCheckoutConsumer> logger)
        {
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
        }
        #endregion Constructor

        public async Task Consume(ConsumeContext<BasketCheckoutEvent> context)
        {
            var mapper = _mapper.Map<CheckoutOrderDTO>(context.Message);
            var command = new CheckoutOrderCommand(mapper);
            var result = await _mediator.Send(command);
            _logger.LogInformation($"checkout order command success done and order id is = {result}");
        }
    }
}
