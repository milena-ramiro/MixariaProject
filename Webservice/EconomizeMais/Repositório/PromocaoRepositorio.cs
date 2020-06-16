using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EconomizeMais.Repositório
{
    public class PromocaoRepositorio : IRepositorio<tbPromocao>
    {
        private dbWebMixariaEntities dbMixaria;

        public PromocaoRepositorio(dbWebMixariaEntities db)
        {
            this.dbMixaria = db;
        }

        public IEnumerable<tbPromocao> GetTodos()
        {
            return dbMixaria.tbPromocao.ToList();

        }
        

        public IEnumerable<tbPromocao> GetAlguns(int id)
        {
            return dbMixaria.tbPromocao.Where(p => p.Estab == id).ToList();
        }
    }
}