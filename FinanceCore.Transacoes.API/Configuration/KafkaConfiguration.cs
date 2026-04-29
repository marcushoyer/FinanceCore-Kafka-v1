using FinanceCore.Shared.Contracts;
using MassTransit;

namespace FinanceCore.Transacoes.API.Configuration
{
    public static class KafkaConfiguration
    {
        public static IServiceCollection AddKafkaInfrastructure(this IServiceCollection services)
        {
            services.AddMassTransit(x =>
            {
                // Mantemos o InMemory para o barramento interno se desejar, 
                // mas o Rider (Kafka) precisa estar bem amarrado.
                x.UsingInMemory((context, cfg) => cfg.ConfigureEndpoints(context));

                x.AddRider(rider =>
                {
                    // 1. Registro do Producer
                    rider.AddProducer<MovimentacaoRealizada>("finance.transacoes");

                    // 2. Configuração do Host (Apontando para o nosso Docker corrigido)
                    rider.UsingKafka((context, k) =>
                    {
                        k.Host("localhost:9092");
                    });
                });
            });

            return services;
        }
    }
}