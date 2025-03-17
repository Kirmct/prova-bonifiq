using ProvaPub.Application.Strategies.Interfaces;

namespace ProvaPub.Application.Strategies;
public class CreditCardPaymentStrategy : IPaymentStrategy
{
    public decimal Calculate(decimal paymentValue)
    {
        Console.WriteLine("Creadit Card Payment");
        return paymentValue;
    }
}
