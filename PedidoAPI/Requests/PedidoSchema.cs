using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;
namespace ApiPedidos.Services.Requests

{
    /// <summary>
    /// Classe schema de Pedido
    /// </summary>
    public class PedidoSchema
    {
        public string id { get; set; }
        public int Itens { get; set; }
        public string Customer { get; set; }
        public decimal Total { get; set; }
        public List<ItemSchema> item { get; set; }
        public CustomerSchema CustomerSchema { get; set; }
    }
}
