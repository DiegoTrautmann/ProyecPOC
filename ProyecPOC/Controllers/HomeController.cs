using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyecPOC.Models;


namespace ProyecPOC.Controllers
{
    public class HomeController : Controller
    {
        private BDPOC db = new BDPOC();

        public ActionResult Index()
        {
            var pymes = db.pymes.Include(p => p.categoria).Include(p => p.sub_categoria);
            return View(pymes.ToList());
        }

       

        public ActionResult Tienda()
        {
            ViewBag.Message = "Catálogo de Tiendas.";

             return View();
        }

        public ActionResult Restaurante()
        {
            ViewBag.Message = "Catálogo de Restaurante.";

            return View();
        }

        public ActionResult Servicio()
        {
            ViewBag.Message = "Otro tipo de cosas";

            return View();
        }

       
    }

}