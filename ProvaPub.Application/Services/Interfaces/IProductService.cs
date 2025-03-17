using ProvaPub.Application.DTOs.Product;
using ProvaPub.Domain.Pagination;
using ProvaPub.Domain.Results;

namespace ProvaPub.Application.Services.Interfaces;
public interface IProductService
{
    Task<Result<PagedList<ProductResponseDTO>>> GetProductsPaged(PageParameters pageParameters);
}
