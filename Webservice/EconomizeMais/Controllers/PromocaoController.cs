using EconomizeMais.Repositório;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace EconomizeMais.Controllers
{
    public class PromocaoController : ApiController
    {
        static readonly IRepositorio<tbPromocao> repositorio = new PromocaoRepositorio(new dbWebMixariaEntities());

        public IEnumerable<tbPromocao> GetAllProdutos(int id)
        {
            var produtos = repositorio.GetAlguns(id);
            return produtos;
        }
        
    }
}
