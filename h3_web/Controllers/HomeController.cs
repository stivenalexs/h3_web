using h3_web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace h3_web.Controllers
{
    public class HomeController : Controller
    {
        private DB_MedicosEntities1 db = new DB_MedicosEntities1();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpPost]
         public ActionResult Index(Persona model)
        { if (ModelState.IsValid)
            { var persona = db.SP_Iniciar_Sesion(model.Correo, model.Contraseña).FirstOrDefault();
                if (persona != null) { return RedirectToAction("index", "Citas"); }
            } 
            return View(); 
        }
    }
}