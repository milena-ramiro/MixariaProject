using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EconomizeMais.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Session["usuarioLogadoID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Principal()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(tbUsuario u)
        {
            // esta action trata o post (login)
            if (ModelState.IsValid) //verifica se é válido
            {

                using (dbWebMixariaEntities db = new dbWebMixariaEntities())
                {

                    List<tbUsuario> LstUser;

                    LstUser = (from usu in db.tbUsuario
                               where usu.nome.ToUpper() == u.usuario.ToUpper()
                               where usu.senha == u.senha
                               select usu).ToList();

                    if (LstUser.Count > 0)
                    {

                        Session["Susuario"] = LstUser[0].usuario.ToString();
                        Session["Snomeusuario"] = LstUser[0].nome.ToString();
                        Session["sestab"] = LstUser[0].estab.ToString();

                        return RedirectToAction("Principal");

                    }
                    else
                        return RedirectToAction("Login");
                }
            }
            return View();
        }

    }
}