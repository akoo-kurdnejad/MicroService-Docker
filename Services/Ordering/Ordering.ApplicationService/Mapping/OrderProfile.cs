using AutoMapper;
using Ordering.ApplicationService.Models.DTOs;
using Ordering.ApplicationService.ViewModels;
using Ordering.Domain.Aggregates.OrderAggregate;

namespace Ordering.ApplicationService.Mapping
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrdersVM>().ReverseMap();
            CreateMap<Order, CheckoutOrderDTO>().ReverseMap();
            CreateMap<Order, UpdateOrderDTO>().ReverseMap();
        }
    }
}
