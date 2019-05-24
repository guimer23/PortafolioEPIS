using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PortafolioEPIS.Models;

namespace PortafolioEPIS.Controllers
{
    public class PlanEstudioController : Controller
    {
        private Tbl_PlanEstudio objPlanEstudio = new Tbl_PlanEstudio();
        private Tbl_Semestre objSemestre = new Tbl_Semestre();

        public ActionResult Index()
        {
            return View(objPlanEstudio.Listar());
        }

        //Accion Visualizar

        public ActionResult Ver(int id)
        {
            return View(objPlanEstudio.Obtener(id));
        }

        // Accion Agregar
        public ActionResult Agregar(int id = 0)     
        {
            ViewBag.Tbl_Semestre = objSemestre.Listar();

            return View(id == 0 ? new Tbl_PlanEstudio()//Agregar un nuevo objeto
               : objPlanEstudio.Obtener(id));
        }

        //Action Guardar
        public ActionResult Guardar(Tbl_PlanEstudio objPlanEstudio)
        {
            if (ModelState.IsValid)
            {
                objPlanEstudio.Guardar();
                return Redirect("~/PlanEstudio");
            }
            else
            {
                return View("~/Views/PlanEstudio/Agregar.cshtml");
            }

        }

        //Action Eliminar

        public ActionResult Eliminar(int id)
        {
            objPlanEstudio.Codigo_PlanEstudio = id;
            objPlanEstudio.Eliminar();
            return Redirect("~/PlanEstudio");
        }
    }
}