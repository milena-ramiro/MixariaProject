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
    public class tbPromocaoController : Controller
    {
        private dbWebMixariaEntities db = new dbWebMixariaEntities();

        private IRepositorio<tbPromocao> _repositorioPromocao;

        public tbPromocaoController()
        {
            _repositorioPromocao = new PromocaoRepositorio(new dbWebMixariaEntities());
        }

        public ActionResult Catalogo(int? pagina)
        {
            int tamanhoPagina = 10;
            int numeroPagina = pagina ?? 1;
            return View(_repositorioPromocao.GetTodos().ToPagedList(numeroPagina, tamanhoPagina));
        }

        // GET: tbPromocaos
        //public ActionResult Index()
        //{
        //    var tbPromocao = db.tbPromocao.Include(t => t.tbEstab).Include(t => t.tbProdutos);
        //    return View(tbPromocao.ToList());
        //}

        // GET: tbPromocaos/Details/5
        public ActionResult Details(string id, int? estab, DateTime? inicio, DateTime? fim)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbPromocao tbPromocao = db.tbPromocao.Find(estab,id,inicio.Value.Date,fim.Value.Date);
            if (tbPromocao == null)
            {
                return HttpNotFound();
            }
            return View(tbPromocao);
        }

        // GET: tbPromocaos/Create
        public ActionResult Create()
        {
            ViewBag.estab = new SelectList(db.tbEstab, "Codigo", "Nome");
            ViewBag.produto = new SelectList(db.tbProdutos, "Codigo", "Descricao");
            return View();
        }

        // POST: tbPromocaos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "estab,produto,inicio,fim,preco,promocao,prioridade")] tbPromocao tbPromocao)
        {
            if (ModelState.IsValid)
            {
                db.tbPromocao.Add(tbPromocao);
                db.SaveChanges();
                return RedirectToAction("Catalogo");
            }

            ViewBag.estab = new SelectList(db.tbEstab, "Codigo", "Nome", tbPromocao.Estab);
            ViewBag.produto = new SelectList(db.tbProdutos, "Codigo", "Descricao", tbPromocao.Produto);
            return View(tbPromocao);
        }

        // GET: tbPromocaos/Edit/5
        public ActionResult Edit(string id, int? estab, DateTime? inicio, DateTime? fim)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbPromocao tbPromocao = db.tbPromocao.Find(estab, id, inicio.Value.Date, fim.Value.Date);
            if (tbPromocao == null)
            {
                return HttpNotFound();
            }
            ViewBag.estab = new SelectList(db.tbEstab, "codigo", "nome", tbPromocao.Estab);
            ViewBag.produto = new SelectList(db.tbProdutos, "codigo", "descricao", tbPromocao.Produto);
            return View(tbPromocao);
        }

        // POST: tbPromocaos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "estab,produto,inicio,fim,preco,promocao,prioridade")] tbPromocao tbPromocao)
        {
            /*tbPromocao.inicio = tbPromocao.inicio.Date;
            tbPromocao.fim = tbPromocao.fim.Date;*/

        

            if (ModelState.IsValid)
            {
                db.Entry(tbPromocao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Catalogo");
            }
            ViewBag.estab = new SelectList(db.tbEstab, "codigo", "nome", tbPromocao.Estab);
            ViewBag.produto = new SelectList(db.tbProdutos, "codigo", "descricao", tbPromocao.Produto);
            return View(tbPromocao);
        }

        // GET: tbPromocaos/Delete/5
        public ActionResult Delete(string id, int? estab, DateTime? inicio, DateTime? fim)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbPromocao tbPromocao = db.tbPromocao.Find(estab, id, inicio.Value.Date, fim.Value.Date);
            if (tbPromocao == null)
            {
                return HttpNotFound();
            }
            return View(tbPromocao);
        }

        // POST: tbPromocaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id, int? estab, DateTime? inicio, DateTime? fim)
        {
            tbPromocao tbPromocao = db.tbPromocao.Find(estab, id, inicio.Value.Date, fim.Value.Date);
            db.tbPromocao.Remove(tbPromocao);
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
