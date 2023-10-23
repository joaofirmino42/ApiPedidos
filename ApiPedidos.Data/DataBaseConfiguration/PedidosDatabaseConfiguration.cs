using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiPedidos.Infra.Data.DataBaseConfiguration
{
    /// <summary>
    /// Classe de configuração do Banco de Dados 
    /// </summary>
    public class PedidosDatabaseConfiguration
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string PedidosCollectionName { get; set; } = null!;
    }
}
