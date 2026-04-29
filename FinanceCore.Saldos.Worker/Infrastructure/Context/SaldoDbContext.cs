using Microsoft.EntityFrameworkCore;
using FinanceCore.Saldos.Worker.Domain.Entities;

namespace FinanceCore.Saldos.Worker.Infrastructure.Context
{
    public class SaldoDbContext : DbContext
    {
        // O construtor está perfeito, ele permite que o AddDbContext funcione no Program.cs
        public SaldoDbContext(DbContextOptions<SaldoDbContext> options) : base(options) { }

        public DbSet<Saldo> Saldos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuração explícita da tabela e propriedades
            modelBuilder.Entity<Saldo>(entity =>
            {
                entity.ToTable("Saldos"); // Define o nome da tabela no Postgres
                entity.HasKey(s => s.Id);
                entity.Property(s => s.NumeroConta).IsRequired().HasMaxLength(50);
                entity.Property(s => s.ValorAtual).HasPrecision(18, 2); // Precisão para valores financeiros
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}