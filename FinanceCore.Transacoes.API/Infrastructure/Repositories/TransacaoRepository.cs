using MongoDB.Driver;
using FinanceCore.Transacoes.API.Domain.Entities;
using FinanceCore.Transacoes.API.Domain.Interfaces;

namespace FinanceCore.Transacoes.API.Infrastructure.Repositories;

public class TransacaoRepository : ITransacaoRepository
{
    private readonly IMongoCollection<Transacao> _collection;

    public TransacaoRepository(IMongoClient mongoClient)
    {
        // FinanceCoreDB é o nome que definimos no Docker
        var database = mongoClient.GetDatabase("FinanceCoreDB");
        _collection = database.GetCollection<Transacao>("Transacoes");
    }

    public async Task AdicionarAsync(Transacao transacao)
    {
        await _collection.InsertOneAsync(transacao);
    }
}