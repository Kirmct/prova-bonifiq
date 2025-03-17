using ProvaPub.Application.DTOs.Customer;
using ProvaPub.Domain.Pagination;
using ProvaPub.Domain.Results;

namespace ProvaPub.Application.Services.Interfaces;
public interface ICustomerService
{
    Task<Result<PagedList<CustomerResponseDTO>>> GetCustomersPaged(PageParameters pageParameters);
    Task<Result<bool>> CanPurchase(int customerId, decimal purchaseValue);
}
