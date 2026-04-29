using FinanceCore.Saldos.Worker.Application.Consumers;
using FinanceCore.Shared.Contracts;
using MassTransit;

public static class KafkaConfiguration
{
    public static IServiceCollection AddKafkaInfrastructure(this IServiceCollection services)
    {
        services.AddMassTransit(x =>
        {
            // Precisamos dizer ao MassTransit para usar um Bus "vazio"
            // para que ele possa gerenciar o Rider (Kafka) por dentro.
            x.UsingInMemory((context, cfg) =>
            {
                cfg.ConfigureEndpoints(context);
            });

            x.AddRider(rider =>
            {
                rider.AddConsumer<MovimentacaoConsumidor>();

                rider.UsingKafka((context, k) =>
                {
                    k.Host("localhost:9092");

                    k.TopicEndpoint<MovimentacaoRealizada>("finance.transacoes", "saldos-group", e =>
                    {
                        e.ConfigureConsumer<MovimentacaoConsumidor>(context);
                    });
                });
            });
        });

        return services;
    }
}