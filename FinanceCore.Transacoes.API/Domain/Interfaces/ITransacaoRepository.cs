using FinanceCore.Transacoes.API.Domain.Entities;

namespace FinanceCore.Transacoes.API.Domain.Interfaces;

public interface ITransacaoRepository
{
    // Note que agora ela recebe a Entidade 'Transacao' e não o evento 'MovimentacaoRealizada'
    Task AdicionarAsync(Transacao transacao);
}