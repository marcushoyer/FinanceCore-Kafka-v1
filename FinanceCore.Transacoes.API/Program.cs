using FinanceCore.Transacoes.API.Configuration;
using FinanceCore.Transacoes.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

// 1. Configurações de API e Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); // Ativa a geração do Swagger

// 2. Injeção de Dependência (SOLID/DDD)
//builder.Services.AddMongoDb(builder.Configuration);
builder.Services.AddMongoInfrastructure(builder.Configuration);
builder.Services.AddKafkaInfrastructure();
builder.Services.AddApplicationServices();

var app = builder.Build();

// 3. Ativação da Interface Visual
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "FinanceCore Transações API v1");
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();