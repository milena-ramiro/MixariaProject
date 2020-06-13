using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EconomizeMais;
using EconomizeMais.Repositório;
using PagedList;

namespace EconomizeMais.Controllers
{
    public class tbUsuariosController : Controller
    {
        private dbWebMixariaEntities db = new dbWebMixariaEntities();

        private IRepositorio<tbUsuario> _repositorioUsuario;

        public tbUsuariosController()
        {
            _repositorioUsuario = new UsuarioRepositorio(new dbWebMixariaEntities());
        }

        public ActionResult Catalogo(int? pagina)
        {
            int tamanhoPagina = 5;
            int numeroPagina = pagina ?? 1;

            if (int.Parse(Session["sestab"].ToString()) == 1)
            {
                return View(_repositorioUsuario.GetTodos().ToPagedList(numeroPagina, tamanhoPagina));
            }
            else
            {
                return RedirectToAction("IndexU");

            }
        }

        // GET: tbUsuarios
        //public ActionResult Index()
        //{

        //    if (int.Parse(Session["sestab"].ToString()) == 1)
        //    {
        //        var Usuario = db.tbUsuario.Include(t => t.tbEstab);
        //        return View(Usuario.ToList());
        //    }
        //    else
        //    {
        //        return RedirectToAction("IndexU");

        //    }


        //    //var tbUsuario = db.tbUsuario.Include(t => t.tbEstab);
        //    //return View(tbUsuario.ToList());
        //}

        public ActionResult IndexU()
        {
            int vestab = int.Parse(Session["sestab"].ToString());
            var Usuario = (from a in db.tbEstab
                           from b in a.tbUsuario
                           where a.Codigo == vestab
                           select b);

            return View(Usuario.ToList());
        }

        // GET: tbUsuarios/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbUsuario tbUsuario = db.tbUsuario.SingleOrDefault(m => m.usuario == id.ToString());
            if (tbUsuario == null)
            {
                return HttpNotFound();
            }
            return View(tbUsuario);
        }

        // GET: tbUsuarios/Create
        public ActionResult Create()
        {
            ViewBag.estab = new SelectList(db.tbEstab, "Codigo", "Nome");
            return View();
        }

        // POST: tbUsuarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Estab,Nome,Usuario,Senha")] tbUsuario tbUsuario)
        {
            if (ModelState.IsValid)
            {
                db.tbUsuario.Add(tbUsuario);
                db.SaveChanges();
                return RedirectToAction("Catalogo");
            }

            ViewBag.estab = new SelectList(db.tbEstab, "codigo", "nome", tbUsuario.estab);
            return View(tbUsuario);
        }


        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbUsuario tbUsuario = db.tbUsuario.SingleOrDefault(m => m.usuario == id.ToString());
            if (tbUsuario == null)
            {
                return HttpNotFound();
            }
            ViewBag.estab = new SelectList(db.tbEstab, "Codigo", "Nome", tbUsuario.estab);
            return View(tbUsuario);
        }


        // GET: tbUsuarios/Edit/5
        /*
        public ActionResult Edit(string Codigo)
        {
            if (Codigo == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbUsuario tbUsuario = db.tbUsuario.Find(Codigo);
            if (tbUsuario == null)
            {
                return HttpNotFound();
            }
            ViewBag.estab = new SelectList(db.tbEstab, "Codigo", "Nome", tbUsuario.Estab);
            return View(tbUsuario);
        }

       */

        // POST: tbUsuarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Estab,Nome,Usuario,Senha")] tbUsuario tbUsuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbUsuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Catalogo");
            }
            ViewBag.estab = new SelectList(db.tbEstab, "codigo", "nome", tbUsuario.estab);
            return View(tbUsuario);
        }

        // GET: tbUsuarios/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbUsuario tbUsuario = db.tbUsuario.SingleOrDefault(m => m.usuario == id.ToString());
            if (tbUsuario == null)
            {
                return HttpNotFound();
            }
            return View(tbUsuario);
        }

        // POST: tbUsuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            tbUsuario tbUsuario = db.tbUsuario.SingleOrDefault(m => m.usuario == id.ToString());
            db.tbUsuario.Remove(tbUsuario);
            db.SaveChanges();
            return RedirectToAction("Catalogo");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
