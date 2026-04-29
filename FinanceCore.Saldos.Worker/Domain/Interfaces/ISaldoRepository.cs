using FinanceCore.Saldos.Worker.Domain.Entities;

namespace FinanceCore.Saldos.Worker.Domain.Interfaces
{
    public interface ISaldoRepository
    {
        Task<Saldo?> ObterPorContaAsync(string numeroConta);
        Task CriarSaldoAsync(Saldo saldo);
        Task AtualizarSaldoAsync(Saldo saldo);
    }
}