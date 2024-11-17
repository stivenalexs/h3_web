using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using h3_web.Models;
using EntityState = System.Data.EntityState;

namespace h3_web.Controllers
{
    public class CitasController : Controller
    {
        private DB_MedicosEntities db = new DB_MedicosEntities();

        // GET: Citas
        public ActionResult Index()
        {
            var cita = db.Cita.Include(c => c.Paciente).Include(c => c.Profesional);
            return View(cita.ToList());
        }

        // GET: Citas/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cita cita = db.Cita.Find(id);
            if (cita == null)
            {
                return HttpNotFound();
            }
            return View(cita);
        }

        // GET: Citas/Create
        public ActionResult Create()
        {
            ViewBag.Doc_Paciente = new SelectList(db.Paciente, "Doc_Paciente", "Tipo_documento");
            ViewBag.Doc_Profesional = new SelectList(db.Profesional, "Doc_Pro", "Horario");
            return View();
        }

        // POST: Citas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Cod_Cita,Doc_Paciente,Doc_Profesional,Fecha_Cita,Hora_Cita,Estado")] Cita cita)
        {
            if (ModelState.IsValid)
            {
                db.Cita.Add(cita);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Doc_Paciente = new SelectList(db.Paciente, "Doc_Paciente", "Tipo_documento", cita.Doc_Paciente);
            ViewBag.Doc_Profesional = new SelectList(db.Profesional, "Doc_Pro", "Horario", cita.Doc_Profesional);
            return View(cita);
        }

        // GET: Citas/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cita cita = db.Cita.Find(id);
            if (cita == null)
            {
                return HttpNotFound();
            }
            ViewBag.Doc_Paciente = new SelectList(db.Paciente, "Doc_Paciente", "Tipo_documento", cita.Doc_Paciente);
            ViewBag.Doc_Profesional = new SelectList(db.Profesional, "Doc_Pro", "Horario", cita.Doc_Profesional);
            return View(cita);
        }

        // POST: Citas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Cod_Cita,Doc_Paciente,Doc_Profesional,Fecha_Cita,Hora_Cita,Estado")] Cita cita)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cita).State = (System.Data.Entity.EntityState)EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Doc_Paciente = new SelectList(db.Paciente, "Doc_Paciente", "Tipo_documento", cita.Doc_Paciente);
            ViewBag.Doc_Profesional = new SelectList(db.Profesional, "Doc_Pro", "Horario", cita.Doc_Profesional);
            return View(cita);
        }

        // GET: Citas/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cita cita = db.Cita.Find(id);
            if (cita == null)
            {
                return HttpNotFound();
            }
            return View(cita);
        }

        // POST: Citas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Cita cita = db.Cita.Find(id);
            db.Cita.Remove(cita);
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
