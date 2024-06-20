using AutoMapper;
using EventBus.Messages.Events;
using Ordering.ApplicationService.Models.DTOs;

namespace Ordering.ApplicationService.Mapping
{
    public class EventProfile : Profile
    {
        public EventProfile()
        {
            CreateMap<BasketCheckoutEvent, CheckoutOrderDTO>()
               .ForMember(dest => dest.PaymentMethod, opt => opt.MapFrom(src => src.PaymentMethod))
               .ReverseMap();
        }
    }
}
