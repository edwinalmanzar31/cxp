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
    public class conceptoDePagoesController : Controller
    {
        private cxpEntities db = new cxpEntities();

        [Authorize]
        // GET: conceptoDePagoes
        public ActionResult Index()
        {
            return View(db.conceptoDePagoes.ToList());
        }

        // GET: conceptoDePagoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            conceptoDePago conceptoDePago = db.conceptoDePagoes.Find(id);
            if (conceptoDePago == null)
            {
                return HttpNotFound();
            }
            return View(conceptoDePago);
        }

        // GET: conceptoDePagoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: conceptoDePagoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,descripcion,Estado")] conceptoDePago conceptoDePago)
        {
            if (ModelState.IsValid)
            {
                db.conceptoDePagoes.Add(conceptoDePago);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(conceptoDePago);
        }

        // GET: conceptoDePagoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            conceptoDePago conceptoDePago = db.conceptoDePagoes.Find(id);
            if (conceptoDePago == null)
            {
                return HttpNotFound();
            }
            return View(conceptoDePago);
        }

        // POST: conceptoDePagoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,descripcion,Estado")] conceptoDePago conceptoDePago)
        {
            if (ModelState.IsValid)
            {
                db.Entry(conceptoDePago).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(conceptoDePago);
        }

        // GET: conceptoDePagoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            conceptoDePago conceptoDePago = db.conceptoDePagoes.Find(id);
            if (conceptoDePago == null)
            {
                return HttpNotFound();
            }
            return View(conceptoDePago);
        }

        // POST: conceptoDePagoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            conceptoDePago conceptoDePago = db.conceptoDePagoes.Find(id);
            db.conceptoDePagoes.Remove(conceptoDePago);
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
