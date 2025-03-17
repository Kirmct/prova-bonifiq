using AutoMapper;
using ProvaPub.Application.DTOs.Customer;
using ProvaPub.Application.DTOs.Order;
using ProvaPub.Application.DTOs.Product;
using ProvaPub.Domain.Models;

namespace ProvaPub.Application.Mappings;
public class DomainToDTOMapping : Profile
{
    public DomainToDTOMapping()
    {
        CreateMap<Product, ProductResponseDTO>();
        CreateMap<Order, OrderResponseDTO>()
            .ForMember(dest => dest.OrderDate, opt => opt.MapFrom(src =>
                TimeZoneInfo.ConvertTimeFromUtc(
                    src.OrderDate, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"))
            ));
        CreateMap<Customer, CustomerResponseDTO>();
    }
}
