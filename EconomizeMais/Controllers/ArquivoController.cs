using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EconomizeMais.Controllers
{
    public class ArquivoController : Controller
    {
        // GET: Arquivo
        public ActionResult ExibirImagem(string id)
        {
            using (dbWebMixariaEntities db = new dbWebMixariaEntities())
            {
                var arquivoRetorno = db.tbProdutos.SingleOrDefault(m => m.Codigo == id);
                return File(arquivoRetorno.Imagem, arquivoRetorno.ImagemTipo);
            }
        }

        public ActionResult ExibirLogo(int id)
        {
            using (dbWebMixariaEntities db = new dbWebMixariaEntities())
            {
                var arquivoRetorno = db.tbFabricante.SingleOrDefault(m => m.Codigo == id);
                return File(arquivoRetorno.Logo, arquivoRetorno.LogoTipo);
            }
        }

        public ActionResult ExibirLogoEstab(int id)
        {
            using (dbWebMixariaEntities db = new dbWebMixariaEntities())
            {
                var arquivoRetorno = db.tbEstab.SingleOrDefault(m => m.Codigo == id);
                return File(arquivoRetorno.Logo, arquivoRetorno.LogoTipo);
            }
        }
    }
}