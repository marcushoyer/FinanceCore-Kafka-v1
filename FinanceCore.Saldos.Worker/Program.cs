var builder = Host.CreateApplicationBuilder(args);

// O Program.cs apenas chama as extensões, sem saber os detalhes de implementação
builder.Services.AddDatabaseConfiguration(builder.Configuration); // Responsabilidade de DB
builder.Services.AddKafkaInfrastructure();                        // Responsabilidade de Mensageria
builder.Services.AddDomainServices();                            // Responsabilidade de Regras de Negócio

var host = builder.Build();
host.Run();