using ProvaPub.Application.Strategies.Interfaces;

namespace ProvaPub.Application.Strategies;
public class PixPaymentStrategy : IPaymentStrategy
{
    public decimal Calculate(decimal paymentValue)
    {
        Console.WriteLine("Pix Payment");
        return paymentValue;
    }
}
