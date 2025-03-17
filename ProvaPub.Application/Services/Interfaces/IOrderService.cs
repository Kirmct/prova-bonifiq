using ProvaPub.Application.DTOs.Order;
using ProvaPub.Domain.Results;

namespace ProvaPub.Application.Services.Interfaces;
public interface IOrderService
{
    Task<Result<OrderResponseDTO>> PayOrder(string paymentMethod, decimal paymentValue, int customerId);
}
