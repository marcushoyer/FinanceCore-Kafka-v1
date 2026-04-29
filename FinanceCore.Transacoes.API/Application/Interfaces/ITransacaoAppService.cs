using FinanceCore.Shared.Contracts;

namespace FinanceCore.Transacoes.API.Application.Interfaces;

public interface ITransacaoAppService
{
    // Usamos o record do Shared como DTO de entrada para simplificar o contrato da API
    Task<bool> ProcessarTransacaoAsync(MovimentacaoRealizada request);
}