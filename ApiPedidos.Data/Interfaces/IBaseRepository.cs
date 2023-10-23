using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiPedidos.Infra.Data.Interfaces
{
    /// <summary>
    /// Interface genérica para operações de repositório.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IBaseRepository<TEntity>
    where TEntity : class
    {
        void Inserir(TEntity entity);
        void Alterar(TEntity entity);
        void Excluir(TEntity entity);
        List<TEntity> Consultar();
        TEntity ObterPorId(string id);
    }
}
