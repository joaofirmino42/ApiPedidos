using ApiPedidos.Infra.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiPedidos.Infra.Data.Interfaces
{
    /// <summary>
    /// Interface de repositório para a entidade Pedido
    /// </summary>
    public interface IPedidoRepository : IBaseRepository<Pedido>
    {
    }
}
