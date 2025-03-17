namespace ProvaPub.Application.Strategies.Interfaces;
public interface IPaymentStrategy
{
    public decimal Calculate(decimal paymentValue);

}
