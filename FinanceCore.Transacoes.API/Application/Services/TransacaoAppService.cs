using FinanceCore.Shared.Contracts;
using FinanceCore.Transacoes.API.Application.Interfaces;
using FinanceCore.Transacoes.API.Domain.Entities;
using FinanceCore.Transacoes.API.Domain.Interfaces;
using MassTransit;

namespace FinanceCore.Transacoes.API.Application.Services;

public class TransacaoAppService(
    ITransacaoRepository repository,
    ITopicProducer<MovimentacaoRealizada> producer) : ITransacaoAppService
{
    public async Task<bool> ProcessarTransacaoAsync(MovimentacaoRealizada request)
    {
        // 1. Mapeia para a Entidade de Domínio (Onde as regras de negócio são validadas)
        var transacao = new Transacao(request.NumeroConta, request.Valor, request.Tipo);

        // 2. Persistência na Infraestrutura (MongoDB)
        await repository.AdicionarAsync(transacao);

        // 3. Publicação do Evento para o ecossistema (Kafka)
        await producer.Produce(request);

        return true;
    }
}