using System;

namespace FinanceCore.Shared.Contracts
{
    /// <summary>
    /// Contrato de transporte para visualização de saldo.
    /// Simples e sem lógica de banco de dados.
    /// </summary>
    public class Saldo
    {
        public string NumeroConta { get; set; } = null!;
        public decimal ValorAtual { get; set; }
        public DateTime UltimaAtualizacao { get; set; }
    }
}