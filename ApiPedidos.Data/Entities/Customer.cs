using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiPedidos.Infra.Data.Entities
{
    /// <summary>
    /// Classe de Customer
    /// </summary>
    public class Customer
    {
        public Guid CustomerId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
    }
}
