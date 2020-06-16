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
    public class tbProdutoesController : Controller
    {
        private dbWebMixariaEntities db = new dbWebMixariaEntities();

        private IRepositorio<tbProdutos> _repositorioProduto;

        public tbProdutoesController()
        {
            _repositorioProduto = new ProdutoRepositorio(new dbWebMixariaEntities());
        }

        public ActionResult Catalogo(int? pagina, string searchString)
        {
            int tamanhoPagina = 10;
            int numeroPagina = pagina ?? 1;

            ViewBag.CurrentFilter = searchString;

            var produtos = from p in db.tbProdutos
                           select p;

            if (!String.IsNullOrEmpty(searchString))
            {
                produtos = produtos.Where(p => p.Descricao.Contains(searchString)).OrderBy(p => p.Descricao);
                return View(produtos.ToPagedList(numeroPagina, tamanhoPagina));
            }
            else
            {
                return View(_repositorioProduto.GetTodos().ToPagedList(numeroPagina, tamanhoPagina));
            }
        }


        // GET: tbProdutoes
        //public ActionResult Index()
        //{
        //    var tbProduto = db.tbProdutos.Include(t => t.tbMercado);
        //    return View(tbProduto.ToList());
        //}

        // GET: tbProdutoes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbProdutos tbProduto = db.tbProdutos.Find(id);
            if (tbProduto == null)
            {
                return HttpNotFound();
            }
            return View(tbProduto);
        }

        // GET: tbProdutoes/Create
        public ActionResult Create()
        {
            ViewBag.mercado = new SelectList(db.tbFabricante, "Codigo", "Nome", "Logo");
            var model = new ProdutosViewModel();
            return View(model);
        }

        // POST: tbProdutoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProdutosViewModel model, HttpPostedFileBase upload)
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

            var produto = new tbProdutos();

                if (ModelState.IsValid)
                {
                    if (upload != null && upload.ContentLength > 0)
                    {
                        var arqImagem = new ProdutosViewModel
                        {
                            ImagemTipo = upload.ContentType
                        };
                        using (var reader = new BinaryReader(upload.InputStream))
                        {
                            arqImagem.Imagem = reader.ReadBytes(upload.ContentLength);
                        }
                        produto.Imagem = arqImagem.Imagem;
                        produto.ImagemTipo = arqImagem.ImagemTipo;
                    }

                    produto.Codigo = model.ProdutoId.ToString();
                    produto.Preco = model.Preco;
                    produto.Descricao = model.Descricao;
                    produto.Estoque = model.Estoque;
                    produto.FabricanteId = model.FabricanteId;

                    //lemos a imagem e a seguir os bytes armazenados
                    //using (var binaryReader = new BinaryReader(model.ImageUpload.InputStream))
                    //    produto.Imagem = binaryReader.ReadBytes(model.ImageUpload.ContentLength);


                    db.tbProdutos.Add(produto);
                    db.SaveChanges();
                    return RedirectToAction("Catalogo");
                }
            

            ViewBag.mercado = new SelectList(db.tbFabricante, "Codigo", "Nome", produto.FabricanteId, produto.Imagem);
            return View(produto);
        }
        
        // GET: tbProdutoes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbProdutos tbProduto = db.tbProdutos.Find(id);
            if (tbProduto == null)
            {
                return HttpNotFound();
            }
            ViewBag.mercado = new SelectList(db.tbFabricante, "Codigo", "Nome", tbProduto.FabricanteId, tbProduto.Imagem);
            return View(tbProduto);
        }

        // POST: tbProdutoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Codigo,Descricao,FabricanteId,Estoque,Preco,Imagem,ImagemTipo,")] tbProdutos produto, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                if (upload != null && upload.ContentLength > 0)
                {
                    var arqImagem = new ProdutosViewModel
                    {
                        ImagemTipo = upload.ContentType
                    };
                    using (var reader = new BinaryReader(upload.InputStream))
                    {
                        arqImagem.Imagem = reader.ReadBytes(upload.ContentLength);
                    }
                    produto.Imagem = arqImagem.Imagem;
                    produto.ImagemTipo = arqImagem.ImagemTipo;
                }

                //lemos a imagem e a seguir os bytes armazenados
                //using (var binaryReader = new BinaryReader(model.ImageUpload.InputStream))
                //    produto.Imagem = binaryReader.ReadBytes(model.ImageUpload.ContentLength);
                

                db.Entry(produto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Catalogo");
            }
                    
            
            ViewBag.mercado = new SelectList(db.tbFabricante, "Codigo", "Nome", produto.FabricanteId, produto.Imagem);
            return View(produto);
        }

        // GET: tbProdutoes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbProdutos tbProduto = db.tbProdutos.Find(id);
            if (tbProduto == null)
            {
                return HttpNotFound();
            }
            return View(tbProduto);
        }

        // POST: tbProdutoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            tbProdutos tbProduto = db.tbProdutos.Find(id);
            db.tbProdutos.Remove(tbProduto);
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
