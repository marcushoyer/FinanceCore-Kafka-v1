using MongoDB.Driver;
using FinanceCore.Transacoes.API.Domain;
using FinanceCore.Transacoes.API.Domain.Interfaces;
using FinanceCore.Transacoes.API.Infrastructure.Repositories;

namespace FinanceCore.Transacoes.API.Extensions;

public static class MongoDbExtensions
{
    public static IServiceCollection AddMongoDb(this IServiceCollection services, IConfiguration configuration)
    {
        // Em produção, a string viria do appsettings ou Secret Vault
        var connectionString = "mongodb://admin:mongo_password@localhost:27018";

        services.AddSingleton<IMongoClient>(_ => new MongoClient(connectionString));

        // Registro do Repositório (D do SOLID - Dependency Inversion)
        services.AddScoped<ITransacaoRepository, TransacaoRepository>();

        return services;
    }
}