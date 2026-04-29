using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinanceCore.Saldos.Worker.Migrations
{
    /// <inheritdoc />
    public partial class InitialSaldos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Saldos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    NumeroConta = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ValorAtual = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    UltimaAtualizacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Saldos", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Saldos");
        }
    }
}
