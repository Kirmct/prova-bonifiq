using Microsoft.EntityFrameworkCore;
using ProvaPub.Domain.Models;
using ProvaPub.Domain.Pagination;
using ProvaPub.Domain.Repositories;
using ProvaPub.Infra.Data.Context;
using ProvaPub.Infra.Data.Helpers;

namespace ProvaPub.Infra.Data.Repositories;
public class ProductRepository : Repository<Product>, IProductRepository
{
    public ProductRepository(AppDbContext context) : base(context) { }

    public async Task<PagedList<Product>> GetProdutosPaged(PageParameters pageParameters)
    {
        var query = _context.Products.AsNoTracking().AsQueryable();
        return await PaginationHelper.CreateAsync(query, pageParameters.PageNumber, pageParameters.PageSize);       
    }
}
