using ProvaPub.Domain.Models;

public class Order : Entity
{
    protected Order() { }

    public Order(decimal value,  int customerId)
    {
        if (customerId <= 0) throw new ArgumentException("CustomerId inválido.", nameof(customerId));

        Value = value;
        OrderDate = DateTime.UtcNow;
        CustomerId = customerId;
    }

    public decimal Value { get; private set; }
    public DateTime OrderDate { get; private set; }
    public int CustomerId { get; private set; }
    public Customer Customer { get; private set; } 
}
