

using ApiPedidos.Infra.Data.DataBaseConfiguration;
using ApiPedidos.Infra.Data.Interfaces;
using ApiPedidos.Infra.Data.Repositories;
using PedidoAPI.Configurations;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.Configure<PedidosDatabaseConfiguration>(
    builder.Configuration.GetSection("PedidoDatabase"));

builder.Services.AddSingleton<IPedidoRepository, PedidoRepository>();

// Configurando os controllers da aplicação
builder.Services.AddControllers();
//Adicionando a configuração do Swagger
SwaggerConfiguration.AddSwagger(builder);
// Add services to the container.
var app = builder.Build();
// Habilitar as rotas e endpoints da API
app.UseRouting();
//Configurando o descritor da API
app.UseSwagger();
app.UseSwaggerUI(s =>
{
    s.SwaggerEndpoint("/swagger/v1/swagger.json", "ProjetoAPI");
});
//Executar os serviços
app.UseEndpoints(endpoints =>
{
    _ = endpoints.MapControllers();
});
app.Run();