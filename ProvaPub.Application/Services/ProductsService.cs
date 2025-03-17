using AutoMapper;
using ProvaPub.Application.DTOs.Product;
using ProvaPub.Application.Services.Interfaces;
using ProvaPub.Domain.Erros;
using ProvaPub.Domain.Pagination;
using ProvaPub.Domain.Repositories;
using ProvaPub.Domain.Results;

namespace ProvaPub.Application.Services;
public class ProductsService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public ProductsService(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<Result<PagedList<ProductResponseDTO>>> GetProductsPaged(PageParameters pageParameters)
    {
        try
        {
            var products = await _productRepository.GetProdutosPaged(pageParameters);

            var productsDto = _mapper.Map<IEnumerable<ProductResponseDTO>>(products);

            var result = new PagedList<ProductResponseDTO>(productsDto, pageParameters.PageNumber, pageParameters.PageSize, products.TotalCount);           

            return Result<PagedList<ProductResponseDTO>>.Success(result);
        }
        catch (Exception ex)
        {
            return Result<PagedList<ProductResponseDTO>>.Failure(ErrorMessages.GeneralErros.UnkownError(ex.Message));
        }
    }
}
