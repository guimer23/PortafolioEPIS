using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortafolioEPIS.Controllers.Mantenimiento
{
    public class SemestreController : Controller
    {
        // Accion Listar
        public ActionResult Index()
        {
            return View();
        }
        // Accion Agregar
        public ActionResult Agregar()
        {
            return View();
        }
    }
}