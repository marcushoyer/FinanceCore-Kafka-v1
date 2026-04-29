using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceCore.Shared.Contracts
{
    public class Saldo
    {
        public Guid Id { get; set; }
        public required string NumeroConta { get; set; } 
        public decimal ValorAtual { get; set; }
        public DateTime UltimaAtualizacao { get; set; }
    }
}
