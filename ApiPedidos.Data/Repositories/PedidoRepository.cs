using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using ApiPedidos.Infra.Data.Entities;
using Microsoft.Extensions.Options;
using ApiPedidos.Infra.Data.DataBaseConfiguration;
using ApiPedidos.Infra.Data.Interfaces;
using static MongoDB.Driver.WriteConcern;
using System.Reflection;

namespace ApiPedidos.Infra.Data.Repositories
{
    /// <summary>
    /// Classe para implementar as operações
    /// de banco de dados para Pedido
    /// </summary>
    public class PedidoRepository : IPedidoRepository
    {
        //atributo
        private readonly IMongoCollection<Pedido> _PedidosCollection;
        //método construtor
        public PedidoRepository(IOptions<PedidosDatabaseConfiguration> PedidosDatabaseSettings)
        {
            var mongoClient = new MongoClient(
       PedidosDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                PedidosDatabaseSettings.Value.DatabaseName);

            _PedidosCollection = mongoDatabase.GetCollection<Pedido>(
                PedidosDatabaseSettings.Value.PedidosCollectionName);
        }

        public void Alterar(Pedido entity)
        {
            _PedidosCollection.ReplaceOne(x => x.PedidoId == entity.PedidoId, entity);
        }

        public List<Pedido> Consultar()
        {

            return _PedidosCollection.Find(_ => true).ToList();
        }


        public void Excluir(Pedido entity)
        {
            _PedidosCollection.DeleteOne(p => p.PedidoId == entity.PedidoId);

        }

        public void Inserir(Pedido entity)
        {
            _PedidosCollection.InsertOne(entity);

        }

        public Pedido ObterPorId(string id)
        {
            return _PedidosCollection.Find<Pedido>(p => p.PedidoId == id).FirstOrDefault();

        }
    }
}
