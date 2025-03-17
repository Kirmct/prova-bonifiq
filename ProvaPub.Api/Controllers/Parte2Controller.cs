using Microsoft.AspNetCore.Mvc;
using ProvaPub.Api.Extensions;
using ProvaPub.Application.DTOs.Customer;
using ProvaPub.Application.DTOs.Product;
using ProvaPub.Application.Services.Interfaces;
using ProvaPub.Domain.Pagination;
using ProvaPub.Domain.Results;
using System.Net;

namespace ProvaPub.Api.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class Parte2Controller : ControllerBase
    {
        /// <summary>
        /// Precisamos fazer algumas alterações:
        /// 1 - Não importa qual page é informada, sempre são retornados os mesmos resultados. Faça a correção.
        /// 2 - Altere os códigos abaixo para evitar o uso de "new", como em "new ProductService()". Utilize a Injeção de Dependência para resolver esse problema
        /// 3 - Dê uma olhada nos arquivos /Models/CustomerList e /Models/ProductList. Veja que há uma estrutura que se repete. 
        /// Como você faria pra criar uma estrutura melhor, com menos repetição de código? E quanto ao CustomerService/ProductService. Você acha que seria possível evitar a repetição de código?
        /// 
        /// </summary>
        private readonly IProductService _productService;
        private readonly ICustomerService _customerService;

        public Parte2Controller(IProductService productService, ICustomerService customerService)
        {
            _productService = productService;
            _customerService = customerService;
        }

        [HttpGet("products")]
        [ProducesResponseType(typeof(Result<PagedList<ProductResponseDTO>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Result<PagedList<ProductResponseDTO>>), (int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<Result<PagedList<ProductResponseDTO>>>> ListProducts(
            [FromQuery]PageParameters pageParameters)
        {
            var result = await _productService.GetProductsPaged(pageParameters);

            if (result.IsSuccess)
            {
                Response.AddPageHeader(
                    new PageHeader(result.Value!.CurrentPage, result.Value!.PageSize, result.Value!.TotalCount, result.Value!.TotalPages));
            }

            return result.Map<ActionResult<Result<PagedList<ProductResponseDTO>>>>(
                    onSuccess: data => Ok(data),
                    onFailure: error => BadRequest(error));
        }

        [HttpGet("customers")]
        [ProducesResponseType(typeof(Result<PagedList<CustomerResponseDTO>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Result<PagedList<CustomerResponseDTO>>), (int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<Result<PagedList<CustomerResponseDTO>>>> ListCustomers(
            [FromQuery] PageParameters pageParameters)
        {
            var result = await _customerService.GetCustomersPaged(pageParameters);

            if (result.IsSuccess)
            {
                Response.AddPageHeader(
                    new PageHeader(result.Value!.CurrentPage, result.Value!.PageSize, result.Value!.TotalCount, result.Value!.TotalPages));
            }

            return result.Map<ActionResult<Result<PagedList<CustomerResponseDTO>>>>(
                    onSuccess: data => Ok(data),
                    onFailure: error => BadRequest(error));
        }
    }
}
