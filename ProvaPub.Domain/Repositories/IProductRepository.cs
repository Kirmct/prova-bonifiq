using ProvaPub.Domain.Models;
using ProvaPub.Domain.Pagination;

namespace ProvaPub.Domain.Repositories;
public interface IProductRepository : IRepository<Product>
{
    Task<PagedList<Product>> GetProdutosPaged(PageParameters pageParameters);
}
