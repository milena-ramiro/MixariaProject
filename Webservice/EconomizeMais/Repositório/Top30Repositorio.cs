using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EconomizeMais.Repositório
{
    public class Top30Repositorio : IRepositorio<tbTop30>
    {

        private dbWebMixariaEntities dbMixaria;

        public Top30Repositorio(dbWebMixariaEntities db)
        {
            this.dbMixaria = db;
        }

        public IEnumerable<tbTop30> GetAlguns(int id)
        {
            return null;
        }

        public IEnumerable<tbTop30> GetTodos()
        {
            var produtos = dbMixaria.tbTop30.ToList();

            return produtos;
        }

    }
}