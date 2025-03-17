using Microsoft.AspNetCore.Mvc;
using ProvaPub.Application.DTOs.Order;
using ProvaPub.Application.Services.Interfaces;
using ProvaPub.Domain.Results;
using System.Net;

namespace ProvaPub.Api.Controllers
{

    /// <summary>
    /// Esse teste simula um pagamento de uma compra.
    /// O método PayOrder aceita diversas formas de pagamento. Dentro desse método é feita uma estrutura de diversos "if" para cada um deles.
    /// Sabemos, no entanto, que esse formato não é adequado, em especial para futuras inclusões de formas de pagamento.
    /// Como você reestruturaria o método PayOrder para que ele ficasse mais aderente com as boas práticas de arquitetura de sistemas?
    /// 
    /// Outra parte importante é em relação à data (OrderDate) do objeto Order. Ela deve ser salva no banco como UTC mas deve retornar para o cliente no fuso horário do Brasil. 
    /// Demonstre como você faria isso.
    /// </summary>
    [ApiController]
	[Route("[controller]")]
	public class Parte3Controller :  ControllerBase
	{
        private readonly IOrderService _orderService;

        public Parte3Controller(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("orders")]
        [ProducesResponseType(typeof(Result<OrderResponseDTO>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Result<OrderResponseDTO>), (int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<Result<OrderResponseDTO>>> PlaceOrder(string paymentMethod, decimal paymentValue, int customerId)
		{
            var result = await _orderService.PayOrder(paymentMethod, paymentValue, customerId);

            return result.Map<ActionResult<Result<OrderResponseDTO>>>(
                onSuccess: data => Ok(data),
                onFailure: error => BadRequest(error));
		}
	}
}
