using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using cxp.Models;

namespace cxp.Controllers
{
    public class tiposPersonasController : Controller
    {
        private cxpEntities db = new cxpEntities();

        // GET: tiposPersonas
        [Authorize]
        public ActionResult Index()
        {
            return View(db.tiposPersonas.ToList());
        }

        // GET: tiposPersonas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tiposPersona tiposPersona = db.tiposPersonas.Find(id);
            if (tiposPersona == null)
            {
                return HttpNotFound();
            }
            return View(tiposPersona);
        }

        // GET: tiposPersonas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tiposPersonas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,descripcion")] tiposPersona tiposPersona)
        {
            if (ModelState.IsValid)
            {
                db.tiposPersonas.Add(tiposPersona);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tiposPersona);
        }

        // GET: tiposPersonas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tiposPersona tiposPersona = db.tiposPersonas.Find(id);
            if (tiposPersona == null)
            {
                return HttpNotFound();
            }
            return View(tiposPersona);
        }

        // POST: tiposPersonas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,descripcion")] tiposPersona tiposPersona)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tiposPersona).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tiposPersona);
        }

        // GET: tiposPersonas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tiposPersona tiposPersona = db.tiposPersonas.Find(id);
            if (tiposPersona == null)
            {
                return HttpNotFound();
            }
            return View(tiposPersona);
        }

        // POST: tiposPersonas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tiposPersona tiposPersona = db.tiposPersonas.Find(id);
            db.tiposPersonas.Remove(tiposPersona);
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
