using AutoMapper;
using ProvaPub.Application.DTOs.Customer;
using ProvaPub.Application.Services.Interfaces;
using ProvaPub.Domain.Erros;
using ProvaPub.Domain.Pagination;
using ProvaPub.Domain.Repositories;
using ProvaPub.Domain.Results;

namespace ProvaPub.Application.Services;
public class CustomerService : ICustomerService
{
    public DateTime CurrentTime { get; set; } = DateTime.UtcNow;
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;
    

    public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
    }

    public async Task<Result<PagedList<CustomerResponseDTO>>> GetCustomersPaged(PageParameters pageParameters)
    {
        try
        {
            var customers = await _customerRepository.GetCustomersPaged(pageParameters);

            var customersDto = _mapper.Map<IEnumerable<CustomerResponseDTO>>(customers);

            var result = new PagedList<CustomerResponseDTO>(customersDto, pageParameters.PageNumber, pageParameters.PageSize, customers.TotalCount);

            return Result<PagedList<CustomerResponseDTO>>.Success(result);
        }
        catch (Exception ex)
        {
            return Result<PagedList<CustomerResponseDTO>>.Failure(ErrorMessages.GeneralErros.UnkownError(ex.Message));
        }
    }

    public async Task<Result<bool>> CanPurchase(int customerId, decimal purchaseValue)
    {
        if (customerId <= 0)
            return Result<bool>.Failure(ErrorMessages.CustomerServiceErros.CustomerIdIsInvalid(customerId));

        if (purchaseValue <= 0)
            return Result<bool>.Failure(ErrorMessages.CustomerServiceErros.PurchaseValueIsInvalid(purchaseValue));

        if (!await VerifyIfCustomerIsRegistered(customerId))
            return Result<bool>.Failure(ErrorMessages.CustomerServiceErros.CustomerNotExists(customerId));

        if (!await VerifyCustomerCanBuyThisMonth(customerId))
            return Result<bool>.Failure(ErrorMessages.CustomerServiceErros.CustomerCannotBuyThisMonth(customerId));

        if (!await VerifyCustomerFirstBuy(customerId, purchaseValue))
            return Result<bool>.Failure(ErrorMessages.CustomerServiceErros.CustomerFirstBuy(customerId, purchaseValue));

        if (!IsOnBusinessHours())
            return Result<bool>.Failure(ErrorMessages.CustomerServiceErros.IsBusinessHour());

        return Result<bool>.Success(true);
    }

    private async Task<bool> VerifyIfCustomerIsRegistered(int customerId)
    {
        var customer = await _customerRepository.Get(c => c.Id == customerId);
        return customer != null;
    }

    private async Task<bool> VerifyCustomerCanBuyThisMonth(int customerId)
    {
        return await _customerRepository.GetCustomersPurchasesMonthlyCount(customerId) == 0;
    }

    private async Task<bool> VerifyCustomerFirstBuy(int customerId, decimal purchaseValue)
    {
        var buys = await _customerRepository.GetCustomersPurchasesCount(customerId);
        return buys > 0 || purchaseValue <= 100;
    }

    private bool IsOnBusinessHours()
    {
        var now = CurrentTime;

        if (now.Hour < 8 || now.Hour > 18 || now.DayOfWeek == DayOfWeek.Saturday || now.DayOfWeek == DayOfWeek.Sunday)
            return false;

        return true;
    }

}
