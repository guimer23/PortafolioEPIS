using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PortafolioEPIS.Models;

namespace PortafolioEPIS.Controllers
{
    public class DetalleCargaAcademicaController : Controller
    {

        private Tbl_DetalleCargaAcademica objDetalleCargaAcademica = new Tbl_DetalleCargaAcademica();
        private Tbl_CargaAcademica objCargaAcademica = new Tbl_CargaAcademica();
        private Tbl_PlanEstudio objPlanEstudio = new Tbl_PlanEstudio();
        private Tbl_Docente objDocente = new Tbl_Docente();
        private Tbl_Seccion objSeccion = new Tbl_Seccion();
        private Tbl_DetallePlanEstudio objDetallePlanEstudio = new Tbl_DetallePlanEstudio();
        private  Tbl_Semestre objSemestre= new Tbl_Semestre();

        public ActionResult Index()
        {
            return View(objDetalleCargaAcademica.Listar());
        }

        //Accion Visualizar

        public ActionResult Ver(int id)
        {
            return View(objDetalleCargaAcademica.Obtener(id));
        }

        // Accion Agregar
        public ActionResult Agregar(int id = 0)
        {
            
            ViewBag.Tbl_CargaAcademica = objCargaAcademica.Listar();
            ViewBag.Tbl_CargaAcademica = objPlanEstudio.Listar();
            ViewBag.Tbl_CargaAcademica = objDocente.Listar();
            ViewBag.Tbl_CargaAcademica = objSeccion.Listar();
            ViewBag.Tbl_CargaAcademica = objDetallePlanEstudio.Listar();
            ViewBag.Tbl_CargaAcademica = objSemestre.Listar();

            return View(id == 0 ? new Tbl_DetalleCargaAcademica()//Agregar un nuevo objeto
               : objDetalleCargaAcademica.Obtener(id));
        }

        //Action Guardar
        public ActionResult Guardar(Tbl_DetalleCargaAcademica objDetalleCargaAcademica)
        {
            if (ModelState.IsValid)
            {
                objDetalleCargaAcademica.Guardar();
                return Redirect("~/DetalleCargaAcademica");
            }
            else
            {
                return View("~/Views/DetalleCargaAcademica/Agregar.cshtml");
            }

        }

        //Action Eliminar

        public ActionResult Eliminar(int id)
        {
            objDetalleCargaAcademica.Codigo_DetalleCargaAcademica = id;
            objDetalleCargaAcademica.Eliminar();
            return Redirect("~/DetalleCargaAcademica");
        }
    }
}