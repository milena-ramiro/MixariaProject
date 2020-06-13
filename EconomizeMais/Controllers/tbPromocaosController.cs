using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EconomizeMais;

namespace EconomizeMais.Controllers
{
    public class tbPromocaosController : Controller
    {
        private dbEconomizeeMais db = new dbEconomizeeMais();

        // GET: tbPromocaos
        public ActionResult Index()
        {
            var tbPromocao = db.tbPromocao.Include(t => t.tbEstab).Include(t => t.tbProduto);
            return View(tbPromocao.ToList());
        }

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
            ViewBag.estab = new SelectList(db.tbEstab, "codigo", "nome");
            ViewBag.produto = new SelectList(db.tbProduto, "codigo", "descricao");
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
                return RedirectToAction("Index");
            }

            ViewBag.estab = new SelectList(db.tbEstab, "codigo", "nome", tbPromocao.estab);
            ViewBag.produto = new SelectList(db.tbProduto, "codigo", "descricao", tbPromocao.produto);
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
            ViewBag.estab = new SelectList(db.tbEstab, "codigo", "nome", tbPromocao.estab);
            ViewBag.produto = new SelectList(db.tbProduto, "codigo", "descricao", tbPromocao.produto);
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
                return RedirectToAction("Index");
            }
            ViewBag.estab = new SelectList(db.tbEstab, "codigo", "nome", tbPromocao.estab);
            ViewBag.produto = new SelectList(db.tbProduto, "codigo", "descricao", tbPromocao.produto);
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
            return RedirectToAction("Index");
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
