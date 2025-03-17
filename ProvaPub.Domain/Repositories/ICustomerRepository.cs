using ProvaPub.Domain.Models;
using ProvaPub.Domain.Pagination;

namespace ProvaPub.Domain.Repositories;
public interface ICustomerRepository : IRepository<Customer>
{
    Task<PagedList<Customer>> GetCustomersPaged(PageParameters pageParameters);
    Task<int> GetCustomersPurchasesMonthlyCount(int customerId);
    Task<int> GetCustomersPurchasesCount(int customerId);
}
