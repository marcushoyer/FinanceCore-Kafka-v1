
using static FinanceCore.Shared.Enums.CoreTypes;

namespace FinanceCore.Transacoes.API.Domain.Entities;

public class Transacao
{
    // O ID é privado no set para garantir que não é alterado externamente
    public Guid Id { get; private set; }
    public string NumeroConta { get; private set; }
    public decimal Valor { get; private set; }
    public TipoMovimentacao Tipo { get; private set; }
    public DateTime DataOcorrencia { get; private set; }

    // Construtor de Domínio: Garante que o objeto nasce num estado válido (Invariantes)
    public Transacao(string numeroConta, decimal valor, TipoMovimentacao tipo)
    {
        if (string.IsNullOrWhiteSpace(numeroConta))
            throw new ArgumentException("O número da conta é obrigatório.");

        if (valor <= 0)
            throw new ArgumentException("O valor da transação deve ser maior que zero.");

        Id = Guid.NewGuid();
        NumeroConta = numeroConta;
        Valor = valor;
        Tipo = tipo;
        DataOcorrencia = DateTime.UtcNow;
    }

    // Construtor necessário para mapeadores de persistência (como o MongoDB)
    protected Transacao()
    {
        NumeroConta = null!; // Resolve o aviso CS8618
    }
}