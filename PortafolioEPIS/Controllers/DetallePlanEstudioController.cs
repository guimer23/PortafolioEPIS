using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PortafolioEPIS.Models;

namespace PortafolioEPIS.Controllers
{
    public class DetallePlanEstudioController : Controller
    {
        private Tbl_DetallePlanEstudio objDetallePlanEstudio = new Tbl_DetallePlanEstudio();
        private Tbl_PlanEstudio objPlanEstudio = new Tbl_PlanEstudio();

        public ActionResult Index()
        {
            return View(objDetallePlanEstudio.Listar());
        }

        //Accion Visualizar

        public ActionResult Ver(int id)
        {
            return View(objDetallePlanEstudio.Obtener(id));
        }

        // Accion Agregar
        public ActionResult Agregar(int id = 0)
        {
            ViewBag.Tbl_PlanEstudio = objPlanEstudio.Listar();

            return View(id == 0 ? new Tbl_DetallePlanEstudio()//Agregar un nuevo objeto
               : objDetallePlanEstudio.Obtener(id));
        }

        //Action Guardar
        public ActionResult Guardar(Tbl_DetallePlanEstudio objDetallePlanEstudio)
        {
            if (ModelState.IsValid)
            {
                objDetallePlanEstudio.Guardar();
                return Redirect("~/DetallePlanEstudio");
            }
            else
            {
                return View("~/Views/DetallePlanEstudio/Agregar.cshtml");
            }

        }

        //Action Eliminar

        public ActionResult Eliminar(int id)
        {
            objDetallePlanEstudio.Codigo_DetallePlanEstudio = id;
            objDetallePlanEstudio.Eliminar();
            return Redirect("~/DetallePlanEstudio");
        }
    }
}