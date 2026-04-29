using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace FinanceCore.Saldos.Worker.Infrastructure.Context
{
    public class SaldoDbContextFactory : IDesignTimeDbContextFactory<SaldoDbContext>
    {
        public SaldoDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SaldoDbContext>();

            // Use a string de conexão direta para o PostgreSQL no Docker
            // Certifique-se de que o Database name e credenciais batem com o seu docker-compose
            optionsBuilder.UseNpgsql("Host=localhost;Port=5434;Database=FinanceCoreDB;Username=admin;Password=root_password");

            return new SaldoDbContext(optionsBuilder.Options);
        }
    }
}