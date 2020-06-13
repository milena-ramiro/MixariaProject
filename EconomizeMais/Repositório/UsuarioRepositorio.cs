using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EconomizeMais.Repositório
{
    public class UsuarioRepositorio : IRepositorio<tbUsuario>
    {
        private dbWebMixariaEntities dbMixaria;

        public UsuarioRepositorio(dbWebMixariaEntities db)
        {
            this.dbMixaria = db;
        }

        public IEnumerable<tbUsuario> GetAlguns(int id)
        {
            return null;
        }

        public IEnumerable<tbUsuario> GetTodos()
        {
            return dbMixaria.tbUsuario.ToList();
        }
    }
}