using Microsoft.AspNetCore.Mvc;
using ProvaPub.Application.Services.Interfaces;
using ProvaPub.Domain.Results;
using System.Net;

namespace ProvaPub.Api.Controllers
{
    /// <summary>
    /// Ao rodar o código abaixo o serviço deveria sempre retornar um número diferente, mas ele fica retornando sempre o mesmo número.
    /// 1 - Faça as alterações para que o retorno seja sempre diferente
    /// 2 - Tome cuidado 
    /// </summary>
    [ApiController]
	[Route("[controller]")]
	public class Parte1Controller :  ControllerBase
	{
		private readonly IRandomService _randomService;

		public Parte1Controller(IRandomService randomService)
		{
			_randomService = randomService;
        }

		[HttpGet]
        [ProducesResponseType(typeof(Result<int>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Result<int>), (int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<Result<int>>> Index()
		{
			var result = await _randomService.GetRandom();

			return result.Map<ActionResult<Result<int>>>(
				onSuccess: data => Ok(data),
				onFailure: error => BadRequest(error));

        }
	}
}
