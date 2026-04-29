using FinanceCore.Shared.Contracts;
using FinanceCore.Transacoes.API.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCore.Transacoes.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransacoesController(ITransacaoAppService appService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] MovimentacaoRealizada request)
        {
            await appService.ProcessarTransacaoAsync(request);
            return Ok("Transação enviada com sucesso!");
        }
    }
}
