using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using h3_web.Models;

namespace h3_web.Controllers
{
    public class ProfesionalsController : Controller
    {
        private DB_MedicosEntities db = new DB_MedicosEntities();

        // GET: Profesionals
        public ActionResult Index()
        {
            var profesional = db.Profesional.Include(p => p.Horario1).Include(p => p.Persona);
            return View(profesional.ToList());
        }

        // GET: Profesionals/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profesional profesional = db.Profesional.Find(id);
            if (profesional == null)
            {
                return HttpNotFound();
            }
            return View(profesional);
        }

        // GET: Profesionals/Create
        public ActionResult Create()
        {
            ViewBag.Horario = new SelectList(db.Horario, "ID_Horario", "Especialidad");
            ViewBag.Doc_Pro = new SelectList(db.Persona, "ID_Persona", "Documento");
            return View();
        }

        // POST: Profesionals/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Doc_Pro,Horario")] Profesional profesional)
        {
            if (ModelState.IsValid)
            {
                db.Profesional.Add(profesional);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Horario = new SelectList(db.Horario, "ID_Horario", "Especialidad", profesional.Horario);
            ViewBag.Doc_Pro = new SelectList(db.Persona, "ID_Persona", "Documento", profesional.Doc_Pro);
            return View(profesional);
        }

        // GET: Profesionals/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profesional profesional = db.Profesional.Find(id);
            if (profesional == null)
            {
                return HttpNotFound();
            }
            ViewBag.Horario = new SelectList(db.Horario, "ID_Horario", "Especialidad", profesional.Horario);
            ViewBag.Doc_Pro = new SelectList(db.Persona, "ID_Persona", "Documento", profesional.Doc_Pro);
            return View(profesional);
        }

        // POST: Profesionals/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Doc_Pro,Horario")] Profesional profesional)
        {
            if (ModelState.IsValid)
            {
                db.Entry(profesional).State = (System.Data.Entity.EntityState)System.Data.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Horario = new SelectList(db.Horario, "ID_Horario", "Especialidad", profesional.Horario);
            ViewBag.Doc_Pro = new SelectList(db.Persona, "ID_Persona", "Documento", profesional.Doc_Pro);
            return View(profesional);
        }

        // GET: Profesionals/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profesional profesional = db.Profesional.Find(id);
            if (profesional == null)
            {
                return HttpNotFound();
            }
            return View(profesional);
        }

        // POST: Profesionals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Profesional profesional = db.Profesional.Find(id);
            db.Profesional.Remove(profesional);
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
