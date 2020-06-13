using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Linq;
namespace EconomizeMais.Repositório
{
    public class ProdutoRepositorio : IRepositorio<tbProdutos>
    {
        private dbWebMixariaEntities dbMixaria;

        public ProdutoRepositorio(dbWebMixariaEntities db)
        {
            this.dbMixaria = db;
        }

        public IEnumerable<tbProdutos> GetAlguns(int id)
        {
            return null;
        }

        public IEnumerable<tbProdutos> GetTodos()
        {
            var produtos = dbMixaria.tbProdutos.ToList();
            
            return produtos;
        }
    }
}