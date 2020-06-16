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
    public class tbEstabController : Controller
    {

        private dbWebMixariaEntities db = new dbWebMixariaEntities();

        private IRepositorio<tbEstab> _repositorioProduto;

        public tbEstabController()
        {
            _repositorioProduto = new EstabRepositorio(new dbWebMixariaEntities());
        }

        public ActionResult Catalogo(int? pagina)
        {
            int tamanhoPagina = 10;
            int numeroPagina = pagina ?? 1;
            return View(_repositorioProduto.GetTodos().ToPagedList(numeroPagina, tamanhoPagina));
        }

        // GET: tbEstab/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbEstab estab = db.tbEstab.Find(id);
            if (estab == null)
            {
                return HttpNotFound();
            }
            return View(estab);
        }

        // GET: tbEstab/Create
        public ActionResult Create()
        {
            ViewBag.tipo = new SelectList(db.tbTipoEst, "Codigo", "Descricao");
            ViewBag.municipio = new SelectList(db.tbMunicipio, "Codigo", "Nome", "UF");
            var model = new EstabViewModel();
            return View(model);
        }

        // POST: tbEstab/Create
        [HttpPost]
        public ActionResult Create(EstabViewModel model, HttpPostedFileBase upload)
        {
            var imageTypes = new string[]{
                    "image/gif",
                    "image/jpeg",
                    "image/pjpeg",
                    "image/png"
                };

            var estabelecimento = new tbEstab();

            if (ModelState.IsValid)
            {
                if (upload != null && upload.ContentLength > 0)
                {
                    var arqImagem = new EstabViewModel
                    {
                        LogoTipo = upload.ContentType
                    };
                    using (var reader = new BinaryReader(upload.InputStream))
                    {
                        arqImagem.Logo = reader.ReadBytes(upload.ContentLength);
                    }
                    estabelecimento.Logo = arqImagem.Logo;
                    estabelecimento.LogoTipo = arqImagem.LogoTipo;
                }

                estabelecimento.Codigo = model.Codigo;
                estabelecimento.Nome = model.Nome;
                estabelecimento.Rua = model.Rua;
                estabelecimento.Nro = model.Nro;
                estabelecimento.Bairro = model.Bairro;
                estabelecimento.TipoEst = model.TipoEst;
                estabelecimento.Municipio = model.MunicipioId;

                //lemos a imagem e a seguir os bytes armazenados
                //using (var binaryReader = new BinaryReader(model.ImageUpload.InputStream))
                //    produto.Imagem = binaryReader.ReadBytes(model.ImageUpload.ContentLength);


                db.tbEstab.Add(estabelecimento);
                db.SaveChanges();
                return RedirectToAction("Catalogo");
            }

            ViewBag.tipo = new SelectList(db.tbTipoEst, "Codigo", "Descricao");
            ViewBag.municipio = new SelectList(db.tbMunicipio, "Codigo", "Nome", "UF");
            
            return View(estabelecimento);
        }

        // GET: tbEstab/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbEstab estab = db.tbEstab.Find(id);
            if (estab == null)
            {
                return HttpNotFound();
            }
            ViewBag.tipo = new SelectList(db.tbTipoEst, "Codigo", "Descricao");
            ViewBag.municipio = new SelectList(db.tbMunicipio, "Codigo", "Nome", "UF");
            return View(estab);
        }

        // POST: tbEstab/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "Codigo,Nome,Rua,Nro,Bairro,TipoEst,Municipio,Logo,LogoTipo")] tbEstab estab, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                if (upload != null && upload.ContentLength > 0)
                {
                    var arqImagem = new EstabViewModel
                    {
                        LogoTipo = upload.ContentType
                    };
                    using (var reader = new BinaryReader(upload.InputStream))
                    {
                        arqImagem.Logo = reader.ReadBytes(upload.ContentLength);
                    }
                    estab.Logo = arqImagem.Logo;
                    estab.LogoTipo = arqImagem.LogoTipo;
                }

                //lemos a imagem e a seguir os bytes armazenados
                //using (var binaryReader = new BinaryReader(model.ImageUpload.InputStream))
                //    produto.Imagem = binaryReader.ReadBytes(model.ImageUpload.ContentLength);


                db.Entry(estab).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Catalogo");
            }


            ViewBag.tipo = new SelectList(db.tbTipoEst, "Codigo", "Descricao");
            ViewBag.municipio = new SelectList(db.tbMunicipio, "Codigo", "Nome", "UF");
            return View(estab);
        }

        // GET: tbEstab/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbEstab estab = db.tbEstab.Find(id);
            if (estab == null)
            {
                return HttpNotFound();
            }
            return View(estab);
        }

        // POST: tbEstab/Delete/5
        // POST: tbProdutoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            tbEstab estab = db.tbEstab.Find(id);
            db.tbEstab.Remove(estab);
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
