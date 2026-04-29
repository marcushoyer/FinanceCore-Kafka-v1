using FinanceCore.Saldos.Worker.Domain.Interfaces;
using FinanceCore.Saldos.Worker.Infrastructure.Repositories;

public static class DomainConfiguration
{
    public static IServiceCollection AddDomainServices(this IServiceCollection services)
    {
        // DIP: Dependemos de interfaces (ISaldoRepository) e não de classes concretas
        services.AddScoped<ISaldoRepository, SaldoRepository>();

        // Se você tiver serviços de domínio (Service classes), registre-os aqui
        // services.AddScoped<ISaldoService, SaldoService>();

        return services;
    }
}