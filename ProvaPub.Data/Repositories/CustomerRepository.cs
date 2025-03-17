using Microsoft.EntityFrameworkCore;
using ProvaPub.Domain.Models;
using ProvaPub.Domain.Pagination;
using ProvaPub.Domain.Repositories;
using ProvaPub.Infra.Data.Context;
using ProvaPub.Infra.Data.Helpers;

namespace ProvaPub.Infra.Data.Repositories;
public class CustomerRepository : Repository<Customer>, ICustomerRepository
{
    public CustomerRepository(AppDbContext context) : base(context) { }

    public async Task<PagedList<Customer>> GetCustomersPaged(PageParameters pageParameters)
    {
        var query = _context.Customers.AsNoTracking().Include(c => c.Orders).AsQueryable();

        return await PaginationHelper.CreateAsync(query, pageParameters.PageNumber, pageParameters.PageSize);
    }

    public async Task<int> GetCustomersPurchasesMonthlyCount(int customerId)
    {
        var baseDate = DateTime.UtcNow.AddMonths(-1);
        return await _context.Orders.CountAsync(s => s.CustomerId == customerId && s.OrderDate >= baseDate);
    }

    public async Task<int> GetCustomersPurchasesCount(int customerId)
    {
        return await _context.Orders.CountAsync(o => o.CustomerId == customerId);
    }
}
