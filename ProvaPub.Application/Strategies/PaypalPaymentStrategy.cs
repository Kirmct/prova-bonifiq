using ProvaPub.Application.Strategies.Interfaces;

namespace ProvaPub.Application.Strategies;
public class PaypalPaymentStrategy : IPaymentStrategy
{
    public decimal Calculate(decimal paymentValue)
    {
        Console.WriteLine("Paypal Payment");
        return paymentValue;
    }
}
