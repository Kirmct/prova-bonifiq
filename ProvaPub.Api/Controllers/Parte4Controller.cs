using Microsoft.AspNetCore.Mvc;
using ProvaPub.Application.Services.Interfaces;
using ProvaPub.Domain.Results;
using System.Net;

namespace ProvaPub.Api.Controllers
{

    /// <summary>
    /// O Código abaixo faz uma chmada para a regra de negócio que valida se um consumidor pode fazer uma compra.
    /// Crie o teste unitário para esse Service. Se necessário, faça as alterações no código para que seja possível realizar os testes.
    /// Tente criar a maior cobertura possível nos testes.
    /// 
    /// Utilize o framework de testes que desejar. 
    /// Crie o teste na pasta "Tests" da solution
    /// </summary>
    [ApiController]
	[Route("[controller]")]
	public class Parte4Controller :  ControllerBase
	{
        private readonly ICustomerService _customerService;

        public Parte4Controller(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("CanPurchase")]
        [ProducesResponseType(typeof(Result<bool>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Result<bool>), (int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<Result<bool>>> CanPurchase(int customerId, decimal purchaseValue)
		{
            var result = await _customerService.CanPurchase(customerId, purchaseValue);

            return result.Map<ActionResult<Result<bool>>>(
                   onSuccess: data => Ok(data),
                   onFailure: error => BadRequest(error));
        }
	}
}
