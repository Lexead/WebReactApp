using AutoMapper;
using WebReactApp.Server.Models;
using WebReactApp.Server.ViewModels;

namespace WebReactApp.Server.Mappers
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderCreateDTO>().ReverseMap();
            CreateMap<Order, OrderViewDTO>().ReverseMap();
        }
    }
}
