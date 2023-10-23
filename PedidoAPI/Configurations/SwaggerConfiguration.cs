using Microsoft.OpenApi.Models;
namespace PedidoAPI.Configurations
{
    /// <summary>
    /// Classe para configuração da documentação do Swagger
    /// </summary>
    public class SwaggerConfiguration
    {
        public static void AddSwagger(WebApplicationBuilder builder)
        {
            builder.Services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "API para controle de Pedidos",
                    Description = "Projeto desenvolvido em NET7 API",
                    Contact = new OpenApiContact
                    {
                        Name = "Api Pedidos",

                        Email = "joaofirmino6@gmail.com"
                    }
                });
            });
        }

    }
}

