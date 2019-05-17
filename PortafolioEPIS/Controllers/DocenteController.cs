using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PortafolioEPIS.Models;

namespace PortafolioEPIS.Controllers
{
    public class DocenteController : Controller
    {
        private Tbl_Docente objDocente = new Tbl_Docente();
        // Accion Listar
        public ActionResult Index()
        {
            return View();
        }
        // Accion Listar Mosaico
        public ActionResult Index2()
        {
            return View(objDocente.Listar2());
        }
        // Accion Agregar
        public ActionResult Agregar()
        {
            return View();
        }
        // Accion Ver
        public ActionResult Ver()
        {
            return View();
        }
    }
}