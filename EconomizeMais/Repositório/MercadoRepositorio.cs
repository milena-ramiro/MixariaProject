using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EconomizeMais.Repositório
{
    public class MercadoRepositorio : IRepositorio<tbFabricante>
    {
        private dbWebMixariaEntities dbMixaria;

        public MercadoRepositorio(dbWebMixariaEntities db)
        {
            this.dbMixaria = db;
        }

        public IEnumerable<tbFabricante> GetAlguns(int id)
        {
            return null;
        }

        public IEnumerable<tbFabricante> GetTodos()
        {
            return dbMixaria.tbFabricante.ToList();
        }
    }
}