using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiPedidos.Infra.Data.Entities
{
    /// <summary>
    /// Classe de Item
    /// </summary>
    public class Item
    {
        public string Nome { get; set; }
        public decimal ValorItem { get; set; }
        public Guid id { get; set; }
    }
}
