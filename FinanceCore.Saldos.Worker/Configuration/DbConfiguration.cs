using Microsoft.EntityFrameworkCore;
using FinanceCore.Saldos.Worker.Infrastructure.Context;

public static class DbConfiguration
{
    public static IServiceCollection AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        // SRP: Centraliza a conexão com o banco aqui
        services.AddDbContext<SaldoDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

        return services;
    }
}