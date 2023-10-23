# Minha API  REST

Este pequeno projeto simula um serviço de cartão de credito que o usuario pode realizar uma compra, cancelar, e estornar.

O objetivo aqui é apresetar uma API emplementada seguindo o estilo REST.

As principais tecnologias que serão utilizadas aqui é o:

- [OpenAPI3](https://swagger.io/specification/)
- [MongoDB](https://www.mongodb.com/pt-br)
- [.NET7.0](https://learn.microsoft.com/pt-br/dotnet/core/whats-new/dotnet-7)
- [MongoDB C# Driver](https://www.mongodb.com/docs/drivers/csharp/current/)

---
### Instalação

Será necessário ter todas as libs instaladas.
> É necessário ter o MongoDB e o MongoDB Shell instalados no Computador
> É fortemente indicado o uso do Visual Studio 2022 para executar o projeto
> Na janela Console do Gerenciador de Pacotes, navegue até a raiz do projeto. Execute o seguinte comando para instalar o driver .NET para MongoDB:

```
Install-Package MongoDB.Driver
```
---
### Executando o servidor


Para executar a API  basta executar o projeto no VisualStudio 2022:

```
---
### Acesso no browser

Abra o [http://localhost:5032/swagger/index.html](http://localhost:5032/swagger/index.html) no navegador para verificar o status da API em execução.
---
### Rotas da API
[HttpPOST]
/Api/Pedidos
> Função post de realiza o cadastro do pedido junto com os dados dos Itens e os dados do Costumer. O Pedido é cadastrado com Status Pendente

[HttpGET]
/Api/Pedidos
> Função que Retornar todos os Pedidos cadastrados

[HttpPATCH]
/Api/Pedidos/Pagar/{id}
> Função que modifica o status do pedido para Pago

[HttpDELETE]
/Api/Pedidos/Cancelar/{id}
> Função que modifica o status do pedido para Cancelado

[HttpPATCH]
/Api/Pedidos/Estornar/{id}
> Função que modifica o status Pago para Estornado

[HttpPUT]
/Api/Pedidos/{id}
> Função que adiciona um Item ao Pedido alteraldo o valor Total

[HttpGET]
/Api/Pedidos/{id}

> Função que retornar o pedido que estiver cadastrado com o id digitado na rota