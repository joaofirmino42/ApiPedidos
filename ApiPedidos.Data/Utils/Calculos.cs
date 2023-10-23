using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiPedidos.Infra.Data.Utils
{
    /// <summary>
    /// Classe de Calculos
    /// 
    /// </summary>
    public static class Calculos
    {
        public static decimal calculaTotal(decimal valor, decimal total)
        {
            total = valor + total;
            return total;
        }
    }
}
