using ProvaPub.Application.DTOs.Order;

namespace ProvaPub.Application.DTOs.Customer;
public class CustomerResponseDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public IEnumerable<OrderResponseDTO> Orders { get; set; } = new List<OrderResponseDTO>();
}
