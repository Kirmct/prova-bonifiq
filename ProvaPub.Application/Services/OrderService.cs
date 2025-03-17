using AutoMapper;
using ProvaPub.Application.DTOs.Order;
using ProvaPub.Application.Services.Interfaces;
using ProvaPub.Application.Strategies;
using ProvaPub.Application.Strategies.Interfaces;
using ProvaPub.Domain.Erros;
using ProvaPub.Domain.Models;
using ProvaPub.Domain.Repositories;
using ProvaPub.Domain.Results;

namespace ProvaPub.Application.Services;
public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;

    private static Dictionary<string, IPaymentStrategy> _mapPayment = new()
    {
        { "creditCard", new CreditCardPaymentStrategy() },
        { "pix", new PixPaymentStrategy() },
        { "paypal", new PaypalPaymentStrategy() }
    };


    public OrderService(IOrderRepository orderRepository, ICustomerRepository customerRepository, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _customerRepository = customerRepository;
        _mapper = mapper;
    }

    public async Task<Result<OrderResponseDTO>> PayOrder(string paymentMethod, decimal paymentValue, int customerId)
    {
        try
        {
            var customer = await GetCustomerIfExists(customerId);
            if (customer is null)
                return Result<OrderResponseDTO>.Failure(ErrorMessages.OrderServiceErrors.InvalidCustomer(customerId));

            var value = _mapPayment[paymentMethod].Calculate(paymentValue);
            var order = _orderRepository.Create(new Order(value, customerId));
            var success = await _orderRepository.Save();

            if (!success)
                return Result<OrderResponseDTO>.Failure(ErrorMessages.OrderServiceErrors.ErrorSaveChanges());

            var orderDto = _mapper.Map<OrderResponseDTO>(order);
            return Result<OrderResponseDTO>.Success(orderDto);
        }
        catch (Exception ex)
        {
            return Result<OrderResponseDTO>.Failure(ErrorMessages.GeneralErros.UnkownError(ex.Message));
        }
    }

    private async Task<Customer?> GetCustomerIfExists(int customerId)
    {
        return await _customerRepository.Get(c => c.Id == customerId);
    }
}
