using AutoMapper;
using Basket.Api.DTOs;
using EventBus.Messages.Events;

namespace Basket.Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BasketCheckoutEvent, BasketCheckoutDTO>().ReverseMap();
        }
    }
}
