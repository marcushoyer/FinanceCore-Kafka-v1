using FinanceCore.Saldos.Worker.Domain.Entities;
using FinanceCore.Saldos.Worker.Domain.Interfaces;
using FinanceCore.Saldos.Worker.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace FinanceCore.Saldos.Worker.Infrastructure.Repositories
{
    public class SaldoRepository : ISaldoRepository
    {
        private readonly SaldoDbContext _context;

        public SaldoRepository(SaldoDbContext context)
        {
            _context = context;
        }

        public async Task<Saldo?> ObterPorContaAsync(string numeroConta)
        {
            return await _context.Saldos
                .FirstOrDefaultAsync(s => s.NumeroConta == numeroConta);
        }

        public async Task CriarSaldoAsync(Saldo saldo)
        {
            await _context.Saldos.AddAsync(saldo);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarSaldoAsync(Saldo saldo)
        {
            _context.Saldos.Update(saldo);
            await _context.SaveChangesAsync();
        }
    }
}