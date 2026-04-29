using System;
using System.Collections.Generic;
using System.Text;
using static FinanceCore.Shared.Enums.CoreTypes;

namespace FinanceCore.Shared.Contracts
{
    public record MovimentacaoRealizada(
        Guid TransacaoId,
        string NumeroConta,
        decimal Valor,
        TipoMovimentacao Tipo,
        DateTime DataOcorrencia
    );
}
