using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortafolioEPIS.Controllers.LayoutDocente
{
    public class VistaDocenteController : Controller
    {
        // GET: VistaDocente
        public ActionResult LayoutDocente()
        {
            return View();
        }
        public ActionResult MiPerfil()
        {
            return View();
        }
        public ActionResult MiCargaAcademica()
        {
            return View();
        }
    }
}