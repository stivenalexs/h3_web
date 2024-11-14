using h3_web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace h3_web.Controllers
{
    public class CitaController : Controller
    {
        // GET: Cita
        public ActionResult Index()
        { 
            using (DB_Medicos_Models context = new DB_Medicos_Models())
            {
                return View(context.Cita.ToList());
            }
        }

        // GET: Cita/Details/5
        public ActionResult Details(string cod_cita)
        {
            using (DB_Medicos_Models context = new DB_Medicos_Models())
            {
                return View(context.Cita.Where(x => x.Cod_Cita == cod_cita));
            }
        }

        // GET: Cita/Create
        public ActionResult Create()
        {
            using (DB_Medicos_Models context = new DB_Medicos_Models())
            {
                return View(context.Cita.ToList());
            }
        }

        // POST: Cita/Create
        [HttpPost]
        public ActionResult Create(Cita cita)
        {
            try
            {
                // TODO: Add insert logic here
                using (DB_Medicos_Models context = new DB_Medicos_Models())
                {
                    context.Cita.Add(cita);
                    context.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cita/Edit/5
        public ActionResult Edit(string cod_cita)
        {
            using (DB_Medicos_Models context = new DB_Medicos_Models())
            {
                return View(context.Cita.Where(x => x.Cod_Cita == cod_cita).FirstOrDefault());
            }
        }

        // POST: Cita/Edit/5
        [HttpPost]
        public ActionResult Edit(string cod_cita, Cita cita)
        {
            try
            {
                // TODO: Add update logic here
                using (DB_Medicos_Models context = new DB_Medicos_Models())
                {
                    context.Entry(cita).State =System.Data.EntityState.Modified;
                    context.SaveChanges();

                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cita/Delete/5
        public ActionResult Delete(string cod_cita)
        {
            return View();
        }

        // POST: Cita/Delete/5
        [HttpPost]
        public ActionResult Delete(string cod_cita, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                using (DB_Medicos_Models context = new DB_Medicos_Models())
                {
                    Cita cita =(context.Cita.Where(x => x.Cod_Cita == cod_cita).FirstOrDefault());
                    context.Cita.Remove(cita);
                    context.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
