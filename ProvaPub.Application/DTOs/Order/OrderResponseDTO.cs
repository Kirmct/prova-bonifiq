namespace ProvaPub.Application.DTOs.Order;
public class OrderResponseDTO
{
    public int Id { get; set; }
    public decimal Value { get; set; }
    public int CustomerId { get; set; }
    public DateTime OrderDate { get; set; }
}
