using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EconomizeMais.Repositório
{
    public class EstabRepositorio : IRepositorio<tbEstab>
    {

        private dbWebMixariaEntities dbMixaria;

        private IEnumerable<tbEstab> ESTAB;

        public EstabRepositorio(dbWebMixariaEntities db)
        {
            this.dbMixaria = db;
        }

        public IEnumerable<tbEstab> GetAlguns(int id)
        {
            return null;
        }

        public IEnumerable<tbEstab> GetTodos()
        {
            var estabs = dbMixaria.tbEstab.ToList();
            return estabs;
        }

    }
}