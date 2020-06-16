using EconomizeMais.Repositório;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EconomizeMais.Controllers
{
    public class EstabController : ApiController
    {

        static readonly IRepositorio<tbEstab> repositorio = new EstabRepositorio(new dbWebMixariaEntities());

        public IEnumerable<tbEstab> GetAllEstabs()
        {
            return repositorio.GetTodos();
        }

    }
}
