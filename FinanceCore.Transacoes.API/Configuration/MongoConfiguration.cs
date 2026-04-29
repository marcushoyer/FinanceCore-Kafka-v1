using FinanceCore.Transacoes.API.Domain.Entities;
using FinanceCore.Transacoes.API.Domain.Interfaces;
using FinanceCore.Transacoes.API.Infrastructure.Repositories;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;

namespace FinanceCore.Transacoes.API.Configuration;

public static class MongoConfiguration
{
    public static IServiceCollection AddMongoInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        // 1. Configuração Global de Serialização (DDD: Detalhe de implementação de infra)
        // Resolve o erro de Guid Unspecified de forma global
#pragma warning disable CS0618
        BsonSerializer.RegisterSerializer(new GuidSerializer(GuidRepresentation.Standard));
#pragma warning restore CS0618

        // 2. Mapeamento Fluente (DDD: Mantém o Domínio limpo/POCO)
        // Aqui ensinamos o Mongo a entender a nossa Entidade sem precisar de atributos nela
        if (!BsonClassMap.IsClassMapRegistered(typeof(Transacao)))
        {
            BsonClassMap.RegisterClassMap<Transacao>(cm =>
            {
                cm.AutoMap(); // Mapeia propriedades automáticas

                // Define o Id explicitamente e como ele deve ser persistido
                cm.MapIdProperty(t => t.Id)
                  .SetSerializer(new GuidSerializer(BsonType.String));

                // Se houver propriedades que não devem ir para o banco, use:
                // cm.UnmapProperty(t => t.PropriedadeIgnorada);
            });
        }

        // 3. Configuração da Conexão
        // Em um cenário real, "FinanceCoreDB" viria do appsettings
        var connectionString = "mongodb://admin:mongo_password@localhost:27018/?authSource=admin";

        services.AddSingleton<IMongoClient>(sp => new MongoClient(connectionString));

        // 4. Injeção do Repositório (D do SOLID)
        services.AddScoped<ITransacaoRepository, TransacaoRepository>();

        return services;
    }
}