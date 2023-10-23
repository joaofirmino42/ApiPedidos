using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace ApiPedidos.Infra.Data.Entities
{
    /// <summary>
    /// Classe de Pedido
    /// </summary>
    public class Pedido
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string PedidoId { get; set; }

        public string Status { get; set; }
        public int Itens { get; set; }

        public string Customer { get; set; }
        public decimal Total { get; set; }
        public List<Item> Item { get; set; }
        public Customer Custormer { get; set; }
    }
}
