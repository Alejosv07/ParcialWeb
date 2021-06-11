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
    public class CancionsController : Controller
    {
        private WebApplication3Context12 db = new WebApplication3Context12();

        // GET: Cancions
        public ActionResult Index()
        {
            return View(db.Cancions.ToList());
        }

        // GET: Cancions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cancion cancion = db.Cancions.Find(id);
            if (cancion == null)
            {
                return HttpNotFound();
            }
            return View(cancion);
        }

        // GET: Cancions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cancions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Idcancion,Iddisco,Numero,Tiempo,Cancionn")] Cancion cancion)
        {
            if (ModelState.IsValid)
            {
                db.Cancions.Add(cancion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cancion);
        }

        // GET: Cancions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cancion cancion = db.Cancions.Find(id);
            if (cancion == null)
            {
                return HttpNotFound();
            }
            return View(cancion);
        }

        // POST: Cancions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Idcancion,Iddisco,Numero,Tiempo,Cancionn")] Cancion cancion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cancion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cancion);
        }

        // GET: Cancions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cancion cancion = db.Cancions.Find(id);
            if (cancion == null)
            {
                return HttpNotFound();
            }
            return View(cancion);
        }

        // POST: Cancions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cancion cancion = db.Cancions.Find(id);
            db.Cancions.Remove(cancion);
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
