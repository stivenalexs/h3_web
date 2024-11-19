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
    public class PersonaController : Controller
    {
        private DB_MedicosEntities1 db = new DB_MedicosEntities1();

        // GET: Persona
        public ActionResult Index()
        {
            var persona = db.Persona.Include(p => p.Administrador).Include(p => p.Paciente).Include(p => p.Profesional);
            return View(persona.ToList());
        }

        // GET: Persona/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Persona persona = db.Persona.Find(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            return View(persona);
        }

        // GET: Persona/Create
        public ActionResult Create()
        {
            ViewBag.ID_Persona = new SelectList(db.Administrador, "ID_Persona", "Clave");
            ViewBag.ID_Persona = new SelectList(db.Paciente, "Doc_Paciente", "Tipo_documento");
            ViewBag.ID_Persona = new SelectList(db.Profesional, "Doc_Pro", "Horario");
            return View();
        }

        // POST: Persona/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Persona,Documento,Nombre,Fecha_Nacimiento,Telefono,Correo,Contraseña,Foto,Tipo_Sangre")] Persona persona)
        {
            if (ModelState.IsValid)
            {
                db.Persona.Add(persona);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Persona = new SelectList(db.Administrador, "ID_Persona", "Clave", persona.ID_Persona);
            ViewBag.ID_Persona = new SelectList(db.Paciente, "Doc_Paciente", "Tipo_documento", persona.ID_Persona);
            ViewBag.ID_Persona = new SelectList(db.Profesional, "Doc_Pro", "Horario", persona.ID_Persona);
            return View(persona);
        }

        // GET: Persona/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Persona persona = db.Persona.Find(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Persona = new SelectList(db.Administrador, "ID_Persona", "Clave", persona.ID_Persona);
            ViewBag.ID_Persona = new SelectList(db.Paciente, "Doc_Paciente", "Tipo_documento", persona.ID_Persona);
            ViewBag.ID_Persona = new SelectList(db.Profesional, "Doc_Pro", "Horario", persona.ID_Persona);
            return View(persona);
        }

        // POST: Persona/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Persona,Documento,Nombre,Fecha_Nacimiento,Telefono,Correo,Contraseña,Foto,Tipo_Sangre")] Persona persona)
        {
            if (ModelState.IsValid)
            {
                db.Entry(persona).State = (System.Data.Entity.EntityState)System.Data.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Persona = new SelectList(db.Administrador, "ID_Persona", "Clave", persona.ID_Persona);
            ViewBag.ID_Persona = new SelectList(db.Paciente, "Doc_Paciente", "Tipo_documento", persona.ID_Persona);
            ViewBag.ID_Persona = new SelectList(db.Profesional, "Doc_Pro", "Horario", persona.ID_Persona);
            return View(persona);
        }

        // GET: Persona/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Persona persona = db.Persona.Find(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            return View(persona);
        }

        // POST: Persona/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Persona persona = db.Persona.Find(id);
            db.Persona.Remove(persona);
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
