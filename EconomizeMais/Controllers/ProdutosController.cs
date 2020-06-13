using EconomizeMais.Repositório;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EconomizeMais.Controllers
{
    public class ProdutosController : ApiController
    {
        static readonly IRepositorio<tbProdutos> repositorio = new ProdutoRepositorio(new dbWebMixariaEntities());

        public IEnumerable<tbProdutos> GetAllProdutos()
        {
            return repositorio.GetTodos();
        }

    }
}
