using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Data;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class DetallepedidoesController : Controller
    {
        private WebApplication3Context12 db = new WebApplication3Context12();

        // GET: Detallepedidoes
        public ActionResult Index()
        {
            var detallepedidoes = db.Detallepedidoes.Include(d => d.Disco).Include(d => d.Pedido);
            return View(detallepedidoes.ToList());
        }

        // GET: Detallepedidoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detallepedido detallepedido = db.Detallepedidoes.Find(id);
            if (detallepedido == null)
            {
                return HttpNotFound();
            }
            return View(detallepedido);
        }

        // GET: Detallepedidoes/Create
        public ActionResult Create()
        {
            ViewBag.Iddiscos = new SelectList(db.Discoes, "Iddiscos", "Titulo");
            ViewBag.Idpedido = new SelectList(db.Pedidoes, "Idpedido", "Idpedido");
            return View();
        }

        // POST: Detallepedidoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Iddetalle,Idpedido,Iddiscos,Cantidad,Precioventa")] Detallepedido detallepedido)
        {
            if (ModelState.IsValid)
            {
                db.Detallepedidoes.Add(detallepedido);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Iddiscos = new SelectList(db.Discoes, "Iddiscos", "Titulo", detallepedido.Iddiscos);
            ViewBag.Idpedido = new SelectList(db.Pedidoes, "Idpedido", "Idpedido", detallepedido.Idpedido);
            return View(detallepedido);
        }

        // GET: Detallepedidoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detallepedido detallepedido = db.Detallepedidoes.Find(id);
            if (detallepedido == null)
            {
                return HttpNotFound();
            }
            ViewBag.Iddiscos = new SelectList(db.Discoes, "Iddiscos", "Titulo", detallepedido.Iddiscos);
            ViewBag.Idpedido = new SelectList(db.Pedidoes, "Idpedido", "Direccionentrega", detallepedido.Idpedido);
            return View(detallepedido);
        }

        // POST: Detallepedidoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Iddetalle,Idpedido,Iddiscos,Cantidad,Precioventa")] Detallepedido detallepedido)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detallepedido).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Iddiscos = new SelectList(db.Discoes, "Iddiscos", "Titulo", detallepedido.Iddiscos);
            ViewBag.Idpedido = new SelectList(db.Pedidoes, "Idpedido", "Direccionentrega", detallepedido.Idpedido);
            return View(detallepedido);
        }

        // GET: Detallepedidoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detallepedido detallepedido = db.Detallepedidoes.Find(id);
            if (detallepedido == null)
            {
                return HttpNotFound();
            }
            return View(detallepedido);
        }

        // POST: Detallepedidoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Detallepedido detallepedido = db.Detallepedidoes.Find(id);
            db.Detallepedidoes.Remove(detallepedido);
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
