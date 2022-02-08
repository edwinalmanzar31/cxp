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
    public class proveedoresController : Controller
    {
        private cxpEntities db = new cxpEntities();

        // GET: proveedores
        [Authorize]
        public ActionResult Index()
        {
            var proveedores = db.proveedores.Include(p => p.tiposPersona);
            return View(proveedores.ToList());
        }

        // GET: proveedores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            proveedore proveedore = db.proveedores.Find(id);
            if (proveedore == null)
            {
                return HttpNotFound();
            }
            return View(proveedore);
        }

        // GET: proveedores/Create
        public ActionResult Create()
        {
            ViewBag.tipoPersona = new SelectList(db.tiposPersonas, "id", "descripcion");
            return View();
        }

        // POST: proveedores/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre,tipoPersona,cedula,balance,Estado")] proveedore proveedore)
        {
            if (ModelState.IsValid)
            {
                db.proveedores.Add(proveedore);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.tipoPersona = new SelectList(db.tiposPersonas, "id", "descripcion", proveedore.tipoPersona);
            return View(proveedore);
        }

        // GET: proveedores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            proveedore proveedore = db.proveedores.Find(id);
            if (proveedore == null)
            {
                return HttpNotFound();
            }
            ViewBag.tipoPersona = new SelectList(db.tiposPersonas, "id", "descripcion", proveedore.tipoPersona);
            return View(proveedore);
        }

        // POST: proveedores/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre,tipoPersona,cedula,balance,Estado")] proveedore proveedore)
        {
            if (ModelState.IsValid)
            {
                db.Entry(proveedore).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.tipoPersona = new SelectList(db.tiposPersonas, "id", "descripcion", proveedore.tipoPersona);
            return View(proveedore);
        }

        // GET: proveedores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            proveedore proveedore = db.proveedores.Find(id);
            if (proveedore == null)
            {
                return HttpNotFound();
            }
            return View(proveedore);
        }

        // POST: proveedores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            proveedore proveedore = db.proveedores.Find(id);
            db.proveedores.Remove(proveedore);
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
