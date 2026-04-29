using FinanceCore.Transacoes.API.Application.Interfaces;
using FinanceCore.Transacoes.API.Application.Services;

public static class ApplicationExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<ITransacaoAppService, TransacaoAppService>();
        return services;
    }
}