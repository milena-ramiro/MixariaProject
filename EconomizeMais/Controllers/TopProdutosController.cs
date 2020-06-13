using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EconomizeMais.Repositório;

namespace EconomizeMais.Controllers
{
    public class TopProdutosController : ApiController
    {
        static readonly IRepositorio<tbTop30> repositorio = new Top30Repositorio(new dbWebMixariaEntities());

        public IEnumerable<tbTop30> GetAllProdutos()
        {
            var topProdutos = repositorio.GetTodos();
            return topProdutos;
        }

    }
}
