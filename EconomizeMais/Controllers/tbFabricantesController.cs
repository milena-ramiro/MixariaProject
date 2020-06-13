using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EconomizeMais;
using EconomizeMais.Models;
using EconomizeMais.Repositório;
using PagedList;

namespace EconomizeMais.Controllers
{
    public class tbFabricantesController : Controller
    {
        private dbWebMixariaEntities db = new dbWebMixariaEntities();

        private IRepositorio<tbFabricante> _repositorioMercado;

        public tbFabricantesController()
        {
            _repositorioMercado = new MercadoRepositorio(new dbWebMixariaEntities());
        }

        public ActionResult Catalogo(int? pagina)
        {
            int tamanhoPagina = 10;
            int numeroPagina = pagina ?? 1;
            return View(_repositorioMercado.GetTodos().ToPagedList(numeroPagina, tamanhoPagina));
        }

        //// GET: tbFabricantes
        //public ActionResult Index()
        //{
        //    return View(db.tbMercado.ToList());
        //}

        // GET: tbFabricantes/Details/5
        public ActionResult Details(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbFabricante tbFabricante = db.tbFabricante.Find(id);
            if (tbFabricante == null)
            {
                return HttpNotFound();
            }
            return View(tbFabricante);
        }

        // GET: tbFabricantes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tbFabricantes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FabricantesViewModel model, HttpPostedFileBase upload)
        {

            var imageTypes = new string[]{
                    "image/gif",
                    "image/jpeg",
                    "image/pjpeg",
                    "image/png"
                };
            //if (model.ImageUpload == null || model.ImageUpload.ContentLength == 0)
            //{
            //    ModelState.AddModelError("ImageUpload", "Este campo é obrigatório");
            //}
            //else if (!imageTypes.Contains(model.ImageUpload.ContentType))
            //{
            //    ModelState.AddModelError("ImageUpload", "Escolha uma iamgem GIF, JPG ou PNG.");
            //}

            var fabricante = new tbFabricante();

            if (ModelState.IsValid)
            {
                if (upload != null && upload.ContentLength > 0)
                {
                    var arqImagem = new FabricantesViewModel
                    {
                        LogoTipo = upload.ContentType
                    };
                    using (var reader = new BinaryReader(upload.InputStream))
                    {
                        arqImagem.Logo = reader.ReadBytes(upload.ContentLength);
                    }
                    fabricante.Logo = arqImagem.Logo;
                    fabricante.LogoTipo = arqImagem.LogoTipo;
                }

                fabricante.Codigo = model.Codigo;
                fabricante.Nome = model.Nome;

                ////lemos a imagem e a seguir os bytes armazenados
                //using (var binaryReader = new BinaryReader(model.ImageUpload.InputStream))
                //    mercado.Logo = binaryReader.ReadBytes(model.ImageUpload.ContentLength);


                db.tbFabricante.Add(fabricante);
                db.SaveChanges();
                return RedirectToAction("Catalogo");
            }

            return View(fabricante);
        }

        // GET: tbFabricantes/Edit/5
        public ActionResult Edit(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbFabricante fabricante = db.tbFabricante.Find(id);
            if (fabricante == null)
            {
                return HttpNotFound();
            }
            return View(fabricante);
        }

        // POST: tbFabricantes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Codigo,Nome,Logo,LogoTipo")]tbFabricante fabricante, HttpPostedFileBase upload)
        {
            var imageTypes = new string[]{
                    "image/gif",
                    "image/jpeg",
                    "image/pjpeg",
                    "image/png"
                };
            //if (model.ImageUpload == null || model.ImageUpload.ContentLength == 0)
            //{
            //    ModelState.AddModelError("ImageUpload", "Este campo é obrigatório");
            //}
            //else if (!imageTypes.Contains(model.ImageUpload.ContentType))
            //{
            //    ModelState.AddModelError("ImageUpload", "Escolha uma iamgem GIF, JPG ou PNG.");
            //}


            if (ModelState.IsValid)
            {
                if (upload != null && upload.ContentLength > 0)
                {
                    var arqImagem = new FabricantesViewModel
                    {
                        LogoTipo = upload.ContentType
                    };
                    using (var reader = new BinaryReader(upload.InputStream))
                    {
                        arqImagem.Logo = reader.ReadBytes(upload.ContentLength);
                    }
                    fabricante.Logo = arqImagem.Logo;
                    fabricante.LogoTipo = arqImagem.LogoTipo;
                }

                //lemos a imagem e a seguir os bytes armazenados
                //using (var binaryReader = new BinaryReader(model.ImageUpload.InputStream))
                //    mercado.Logo = binaryReader.ReadBytes(model.ImageUpload.ContentLength);

                db.Entry(fabricante).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Catalogo");
            }
            return View(fabricante);
        }

        // GET: tbFabricantes/Delete/5
        public ActionResult Delete(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbFabricante tbFabricante = db.tbFabricante.Find(id);
            if (tbFabricante == null)
            {
                return HttpNotFound();
            }
            return View(tbFabricante);
        }

        // POST: tbFabricantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(short id)
        {
            tbFabricante tbFabricante = db.tbFabricante.Find(id);
            db.tbFabricante.Remove(tbFabricante);
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
