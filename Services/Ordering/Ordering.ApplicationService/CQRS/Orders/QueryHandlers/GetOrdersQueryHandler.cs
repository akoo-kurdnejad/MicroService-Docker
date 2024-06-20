using AutoMapper;
using Ordering.ApplicationService.CQRS.Orders.Queries;
using Ordering.ApplicationService.ViewModels;
using Ordering.Domain.Repositories;

namespace Ordering.ApplicationService.CQRS.Orders.QueryHandlers
{
    internal class GetOrdersQueryHandler : MediatR.IRequestHandler<GetOrdersQuery, List<OrdersVM>>
    {
        #region Constructor
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public GetOrdersQueryHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }
        #endregion Constructor

        public async Task<List<OrdersVM>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
        {
            var orders = await _orderRepository
                    .GetAsync(c => c.UserName.Equals(request.UserName), cancellationToken);
            
            var result = _mapper.Map<List<OrdersVM>>(orders);
            return result;
        }
    }
}
