using EconomizeMais.Models;
using EconomizeMais.Repositório;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace EconomizeMais.Controllers
{
    public class tbTop30Controller : Controller
    {

        private dbWebMixariaEntities db = new dbWebMixariaEntities();

        private IRepositorio<tbTop30> _repositorioProduto;

        public tbTop30Controller()
        {
            _repositorioProduto = new Top30Repositorio(new dbWebMixariaEntities());
        }

        public ActionResult Catalogo(int? pagina)
        {
            int tamanhoPagina = 10;
            int numeroPagina = pagina ?? 1;
            return View(_repositorioProduto.GetTodos().ToPagedList(numeroPagina, tamanhoPagina));
        }


        // GET: tbProdutoes
        //public ActionResult Index()
        //{
        //    var tbProduto = db.tbProdutos.Include(t => t.tbMercado);
        //    return View(tbProduto.ToList());
        //}

        // GET: tbProdutoes/Details/5
        public ActionResult Details(string produto, int? estab, DateTime? inicio, DateTime? fim)
        {
            if (produto == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbTop30 tbTop30 = db.tbTop30.Find(estab, produto, inicio.Value.Date, fim.Value.Date);
            if (tbTop30 == null)
            {
                return HttpNotFound();
            }
            return View(tbTop30);
        }

        // GET: tbProdutoes/Create
        public ActionResult Create()
        {
            ViewBag.estab = new SelectList(db.tbEstab, "Codigo", "Nome");
            ViewBag.produto = new SelectList(db.tbProdutos, "Codigo", "Descricao");
            //var model = new Top30ViewModel();
            return View();
        }

        // POST: tbProdutoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "estab,produto,inicio,fim,preco,promocao,item_top")] tbTop30 tbTop30)
        {
            if (ModelState.IsValid)
            {
                db.tbTop30.Add(tbTop30);
                db.SaveChanges();
                return RedirectToAction("Catalogo");
            }

            ViewBag.estab = new SelectList(db.tbEstab, "Codigo", "Nome", tbTop30.estab);
            ViewBag.produto = new SelectList(db.tbProdutos, "Codigo", "Descricao", tbTop30.produto);
            return View(tbTop30);
        }

        // GET: tbProdutoes/Edit/5
        public ActionResult Edit(string produto, int estab, DateTime? inicio, DateTime? fim)
        {
            if (produto == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbTop30 tbTop30 = db.tbTop30.Find(estab, produto, inicio.Value.Date, fim.Value.Date);
            if (tbTop30 == null)
            {
                return HttpNotFound();
            }
            ViewBag.estab = new SelectList(db.tbEstab, "codigo", "nome", tbTop30.estab);
            ViewBag.produto = new SelectList(db.tbProdutos, "codigo", "descricao", tbTop30.produto);
            return View(tbTop30);
        }

        // POST: tbProdutoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "estab,produto,inicio,fim,preco,promocao,item_top")] tbTop30 tbTop30)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbTop30).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Catalogo");
            }

            ViewBag.estab = new SelectList(db.tbEstab, "codigo", "nome", tbTop30.estab);
            ViewBag.produto = new SelectList(db.tbProdutos, "codigo", "descricao", tbTop30.produto);
            return View(tbTop30);
        }

        // GET: tbProdutoes/Delete/5
        public ActionResult Delete(string produto, int? estab, DateTime? inicio, DateTime? fim)
        {
            if (produto == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbTop30 tbTop30 = db.tbTop30.Find(estab, produto, inicio.Value.Date, fim.Value.Date);
            if (tbTop30 == null)
            {
                return HttpNotFound();
            }
            return View(tbTop30);
        }

        // POST: tbProdutoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string produto, int? estab, DateTime? inicio, DateTime? fim)
        {
            tbTop30 tbTop30 = db.tbTop30.Find(estab, produto, inicio.Value.Date, fim.Value.Date);
            db.tbTop30.Remove(tbTop30);
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