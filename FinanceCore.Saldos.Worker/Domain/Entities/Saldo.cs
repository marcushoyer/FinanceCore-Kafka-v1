using System;
using System.Diagnostics.CodeAnalysis;

namespace FinanceCore.Saldos.Worker.Domain.Entities
{
    public class Saldo
    {
        public Guid Id { get; private set; }
        public string NumeroConta { get; private set; } = null!;
        public decimal ValorAtual { get; private set; }
        public DateTime UltimaAtualizacao { get; private set; }

        protected Saldo() { }

        [SetsRequiredMembers]
        public Saldo(string numeroConta, decimal valorInicial)
        {
            Id = Guid.NewGuid();
            NumeroConta = numeroConta;
            ValorAtual = valorInicial;
            UltimaAtualizacao = DateTime.UtcNow;
        }

        // A lógica de negócio fica AQUI
        public void AtualizarSaldo(decimal valor, int tipo)
        {
            if (tipo == 1) // Crédito
                ValorAtual += valor;
            else           // Débito
                ValorAtual -= valor;

            UltimaAtualizacao = DateTime.UtcNow;
        }
    }
}