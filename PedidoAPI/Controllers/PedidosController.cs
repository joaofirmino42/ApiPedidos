using ApiPedidos.Infra.Data.Interfaces;
using ApiPedidos.Infra.Data.Entities;
using ApiPedidos.Infra.Data.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApiPedidos.Services.Requests;
using ApiPedidos.Infra.Data.Repositories;
using Amazon.Runtime.Internal;

namespace PedidoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        //atributo
        private readonly IPedidoRepository _pedidoRepository;

        //construtor para inicializar o atributo
        public PedidosController(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;

        }
        //Função que cadastra pedido
        [HttpPost]
        public IActionResult CriarPedido(PedidoSchema request)
        {
            try

            {
                if (!Validacoes.IsEmail(request.CustomerSchema.Email))
                {
                    return StatusCode(400, "Por Favor digite um email");
                }
                if (!Validacoes.IsCpf(request.CustomerSchema.Cpf))
                {
                    return StatusCode(400, "Por Favor digite um cpf válido");
                }
                if (request.Total == 0)
                {
                    return StatusCode(400, "Por Favor digite um valor total");
                }
                if (request.Customer == "" || request.CustomerSchema.Nome == "" || request.Customer == "string" || request.Customer == "string")
                {
                    return StatusCode(400, "Por Favor digite seu nome");
                }
                //Cadastrando costumer
                Customer customer = new Customer();
                customer.Nome = request.CustomerSchema.Nome;
                customer.Cpf = request.CustomerSchema.Cpf;
                customer.Email = request.CustomerSchema.Email;
                customer.CustomerId = Guid.NewGuid();
                Pedido pedido = new Pedido
                {
                    Status = "Pendente",
                    Customer = request.Customer,
                    Itens = request.Itens,
                    Total = request.Total

                };

                pedido.Custormer = customer;
                List<Item> lista = new List<Item>();
                //Cadastrando Item
                foreach (var element in request.item)
                {
                    Item item = new Item();
                    item.id = Guid.NewGuid();
                    item.Nome = element.Nome;
                    item.ValorItem = element.Valor;
                    lista.Add(item);
                }
                pedido.Item = lista;
                //Cadastrando Pedido
                _pedidoRepository.Inserir(pedido);

                return StatusCode(201, "Pedido salvo com sucesso!");
            }
            catch (Exception e)
            {

                //retornando status e mensagem de erro
                //HTTP 500 -> ERRO INTERNO DE SERVIDOR
                return StatusCode(500, e.Message);
            }
        }
        //Função que  altera o status pendente para pago
        [HttpPatch("Pagar/{id}")]
        public IActionResult PagarPedido(string id)
        {
            try
            {
                Pedido pedido = new Pedido();
                pedido = _pedidoRepository.ObterPorId(id);
                if (pedido.Status == "Pendente")
                {
                    pedido.PedidoId = id;
                    pedido.Status = "Pago";

                    _pedidoRepository.Alterar(pedido);
                    return StatusCode(201, "Pedido Pago com sucesso!");
                }
                else
                {
                    return StatusCode(400, "Pedido não está pendente!");
                }

            }
            catch (Exception e)
            {
                //retornando status e mensagem de erro
                //HTTP 500 -> ERRO INTERNO DE SERVIDOR

                return StatusCode(500, e.Message);
            }
        }
        //  Função que  altera o status para candelado
        [HttpDelete("Cancelar/{id}")]
        public IActionResult CancelarPedidoPedido(string id)
        {
            try
            {
                if (id == null)
                {
                    return StatusCode(400, "Por Favor digite o identificador do pedido");
                }
                Pedido pedido = new Pedido();
                pedido = _pedidoRepository.ObterPorId(id);
                if (pedido.Status == "Pendente")
                {

                    pedido.PedidoId = id;
                    pedido.Status = "Cancelado";
                    _pedidoRepository.Alterar(pedido);
                    return StatusCode(201, "Pedido Cancelado com sucesso!");
                }
                else
                {
                    return StatusCode(400, "Pedido Não Está pendente");
                }



            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }
        //  Função que altera o status pago para estornado
        [HttpPatch("Estornar/{id}")]
        public IActionResult EstornarPedido(string id)
        {
            try
            {
                if (id == null)
                {
                    return StatusCode(400, "Por Favor digite o identificador do pedido");
                }
                Pedido pedido = new Pedido();
                pedido = _pedidoRepository.ObterPorId(id);
                if (pedido.Status == "Pago")
                {

                    pedido.Status = "Estornado";
                    _pedidoRepository.Alterar(pedido);
                    return StatusCode(201, "Pedido Estornado com sucesso!");
                }
                else
                {
                    return StatusCode(400, "Pedido Não Está Pago");
                }


            }
            catch (Exception e)
            {
                //retornando status e mensagem de erro
                //HTTP 500 -> ERRO INTERNO DE SERVIDOR

                return StatusCode(500, e.Message);
            }
        }
        // Função que  adiciona Item ao pedido
        [HttpPut("{id}")]
        public IActionResult AdicionarItem(string id, ItemSchema schema)
        {
            try
            {
                if (id == null)
                {
                    return StatusCode(400, "Por Favor digite o identificador do pedido");
                }
                if (schema.Valor == 0)
                {
                    return StatusCode(400, "Por Favor digite o valor do Item");
                }
                var pedido = _pedidoRepository.ObterPorId(id);
                if (pedido.Status != "Pendente")
                {
                    return StatusCode(400, "Pedido não está pendente");
                }
                if (pedido != null)
                {
                    decimal total = Calculos.calculaTotal(pedido.Total, schema.Valor);
                    pedido.Total = total;
                    pedido.Itens = pedido.Itens + 1;

                    Item Item = new Item();
                    Item.Nome = schema.Nome;
                    Item.ValorItem = schema.Valor;
                    Item.id = Guid.NewGuid();
                    pedido.Item.Add(Item);

                    _pedidoRepository.Alterar(pedido);
                    return StatusCode(201, "Item Adicionado com sucesso!");
                }
                else
                {
                    return StatusCode(400, "Pedido não encontrado");
                }

            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }
        //  Função que retorna todos os pedidos
        [HttpGet]
        public IActionResult getALL()
        {
            try
            {
                var pedidos = _pedidoRepository.Consultar();
                return StatusCode(201, pedidos);
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }
        //  Função que  retorna o pedido por id
        [HttpGet("{id}")]
        public IActionResult getById(string id)
        {
            try
            {
                var pedido = _pedidoRepository.ObterPorId(id);
                return StatusCode(201, pedido);
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }



    }
}
