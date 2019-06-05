using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PortafolioEPIS.Models;

namespace PortafolioEPIS.Controllers.Informes
{

   

    public class PruebaEntradaController : Controller
    {
        private Tbl_DetalleCargaAcademica objDetalleCargaAcademica = new Tbl_DetalleCargaAcademica();
        private Tbl_CargaAcademica objCargaAcademica = new Tbl_CargaAcademica();
        private Tbl_PlanEstudio objPlanEstudio = new Tbl_PlanEstudio();
        private Tbl_Docente objDocente = new Tbl_Docente();
        private Tbl_Seccion objSeccion = new Tbl_Seccion();
        private Tbl_DetallePlanEstudio objDetallePlanEstudio = new Tbl_DetallePlanEstudio();
        private Tbl_Semestre objSemestre = new Tbl_Semestre();
        // Accion Listar
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult IndexAdmin()
        {
            return View();
        }
        // Accion Agregar
        public ActionResult Agregar(int id)
        {
            return View(objDetalleCargaAcademica.Obtener(id));
        }
    }
}