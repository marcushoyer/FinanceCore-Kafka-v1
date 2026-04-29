using FinanceCore.Saldos.Worker.Domain.Interfaces; // Certifique-se de importar sua interface
using FinanceCore.Saldos.Worker.Domain.Entities;   // Para criar a entidade Saldo
using FinanceCore.Shared.Contracts;
using MassTransit;
using System.Threading.Tasks;

namespace FinanceCore.Saldos.Worker.Application.Consumers
{
    /// <summary>
    /// Consumidor MassTransit responsável por processar eventos de movimentação financeira.
    /// Atualiza ou cria o saldo das contas de forma assíncrona.
    /// </summary>
    public class MovimentacaoConsumidor : IConsumer<MovimentacaoRealizada>
    {
        private readonly ISaldoRepository _repository;

        // O MassTransit usará o Injetor de Dependências para passar o repositório aqui
        public MovimentacaoConsumidor(ISaldoRepository repository)
        {
            _repository = repository;
        }
        /// <summary>
        /// Processa a mensagem recebida do Kafka. 
        /// Aplica a regra de negócio: Se a conta não existe, inicializa; se existe, atualiza.
        /// </summary>
        public async Task Consume(ConsumeContext<MovimentacaoRealizada> context)
        {
            var dados = context.Message;

            System.Console.WriteLine($"[Consumidor] Processando conta: {dados.NumeroConta} | Valor: {dados.Valor}");

            // 1. Tenta buscar o saldo atual da conta no banco
            var saldoExistente = await _repository.ObterPorContaAsync(dados.NumeroConta);

            if (saldoExistente is null)
            {
                // 2. Se não existe, cria um novo registro (Saldo Inicial)
                // Assumindo que seu construtor de Saldo recebe (numeroConta, valorInicial)
                var novoSaldo = new FinanceCore.Saldos.Worker.Domain.Entities.Saldo(dados.NumeroConta, dados.Valor);
                await _repository.CriarSaldoAsync(novoSaldo);
                System.Console.WriteLine($"[Banco] Novo saldo criado para conta {dados.NumeroConta}");
            }
            else
            {
                // 3. Se já existe, atualiza usando a lógica da sua entidade
                // Supondo que você tenha um método para atualizar o valor
                saldoExistente.AtualizarSaldo(dados.Valor, Convert.ToInt32(dados.Tipo));
                await _repository.AtualizarSaldoAsync(saldoExistente);
                System.Console.WriteLine($"[Banco] Saldo da conta {dados.NumeroConta} atualizado.");
            }
        }
    }
}