using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Data;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class DiscoesController : Controller
    {
        private WebApplication3Context12 db = new WebApplication3Context12();

        // GET: Discoes
        public ActionResult Index()
        {
            var discoes = db.Discoes.Include(d => d.Artista).Include(d => d.Categoria);
            ViewBag.Idcliente = new SelectList(db.Clientes, "Idcliente", "Nombres");
            return View(discoes.ToList());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "Idcliente")] int Idcliente)
        {
            var discos3 = (from _discos in db.Discoes
                           join _detallePedido in db.Detallepedidoes on
                           _discos.Iddiscos equals _detallePedido.Iddiscos
                           join _pedido in db.Pedidoes on _detallePedido.Idpedido equals _pedido.Idpedido
                           join _cliente in db.Clientes on _pedido.Idcliente equals _cliente.Idcliente
                           join _artista in db.Artistas on _discos.Idartista equals _artista.Idartista
                           join _categoria in db.Categorias on _discos.Idcategoria equals _categoria.Idcategoria
                           where _cliente.Idcliente == Idcliente
                           select new { _discos }).ToList();
            ViewBag.Idcliente = new SelectList(db.Clientes, "Idcliente", "Nombres");
            List<Disco> alReturn = new List<Disco>();

            foreach (var item in discos3)
            {
                Disco disco = new Disco();
                disco.Idartista = item._discos.Idartista;
                disco.Artista = db.Artistas.Find(disco.Idartista);
                disco.Idcategoria = item._discos.Idcategoria;
                disco.Categoria = db.Categorias.Find(disco.Idcategoria);
                disco.Titulo = item._discos.Titulo;
                disco.Fecha = item._discos.Fecha;
                disco.Formato = item._discos.Formato;
                disco.Numerocanciones = item._discos.Numerocanciones;
                disco.Precio = item._discos.Precio;
                disco.Observaciones = item._discos.Observaciones;
                disco.Imagen = item._discos.Imagen;
                alReturn.Add(disco);
            }
            return View(alReturn);
        }



        // GET: Discoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Disco disco = db.Discoes.Find(id);
            if (disco == null)
            {
                return HttpNotFound();
            }
            return View(disco);
        }

        //Con esto cargamos los clientes
        public List<Cliente> GetClientes() {
            var query = from _clientes in db.Clientes select _clientes;
            return query.ToList();
        }

        // GET: Discoes/Create
        public ActionResult Create()
        {
            ViewBag.Idartista = new SelectList(db.Artistas, "Idartista", "Nombre");
            ViewBag.Idcategoria = new SelectList(db.Categorias, "Idcategoria", "Ccategoria");
            return View();
        }

        // POST: Discoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Iddiscos,Idcategoria,Idartista,Titulo,Fecha,Formato,Numerocanciones,Precio,Observaciones,ImageFile")] Disco disco)
        {
            if (ModelState.IsValid)
            {
                string fileName = Path.GetFileNameWithoutExtension(disco.ImageFile.FileName);
                string extension = Path.GetExtension(disco.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                disco.Imagen = "/Image/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
                disco.ImageFile.SaveAs(fileName);
                db.Discoes.Add(disco);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Idartista = new SelectList(db.Artistas, "Idartista", "Nombre", disco.Idartista);
            ViewBag.Idcategoria = new SelectList(db.Categorias, "Idcategoria", "Ccategoria", disco.Idcategoria);
            return View(disco);
        }

        // GET: Discoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Disco disco = db.Discoes.Find(id);
            if (disco == null)
            {
                return HttpNotFound();
            }
            ViewBag.Idartista = new SelectList(db.Artistas, "Idartista", "Nombre", disco.Idartista);
            ViewBag.Idcategoria = new SelectList(db.Categorias, "Idcategoria", "Ccategoria", disco.Idcategoria);
            return View(disco);
        }

        // POST: Discoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Iddiscos,Idcategoria,Idartista,Titulo,Fecha,Formato,Numerocanciones,Precio,Observaciones,ImageFile")] Disco disco)
        {
            if (ModelState.IsValid)
            {
                string fileName = Path.GetFileNameWithoutExtension(disco.ImageFile.FileName);
                string extension = Path.GetExtension(disco.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                disco.Imagen = "/Image/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
                disco.ImageFile.SaveAs(fileName);
                db.Entry(disco).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Idartista = new SelectList(db.Artistas, "Idartista", "Nombre", disco.Idartista);
            ViewBag.Idcategoria = new SelectList(db.Categorias, "Idcategoria", "Ccategoria", disco.Idcategoria);
            return View(disco);
        }

        // GET: Discoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Disco disco = db.Discoes.Find(id);
            if (disco == null)
            {
                return HttpNotFound();
            }
            return View(disco);
        }

        // POST: Discoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Disco disco = db.Discoes.Find(id);
            db.Discoes.Remove(disco);
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
