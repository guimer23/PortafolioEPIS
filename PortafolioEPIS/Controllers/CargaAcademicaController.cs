using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using PortafolioEPIS.Models;

namespace PortafolioEPIS.Controllers
{
    public class CargaAcademicaController : Controller
    {
        Tbl_CargaAcademica objCargaAcademica = new Tbl_CargaAcademica();
        Tbl_Semestre objSemestre = new Tbl_Semestre();

        public ActionResult Index()
        {
            return View(objCargaAcademica.Listar());
        }

        //Accion Visualizar

        public ActionResult Ver(int id)
        {
            return View(objCargaAcademica.Obtener(id));
        }

        // Accion Agregar
        public ActionResult Agregar(int id = 0)
        {
            ViewBag.Tbl_Semestre = objSemestre.Listar();

            return View(id == 0 ? new Tbl_CargaAcademica()//Agregar un nuevo objeto
               : objCargaAcademica.Obtener(id));
        }

        //Action Guardar
        public ActionResult Guardar(Tbl_CargaAcademica objCargaAcademica)
        {
            if (ModelState.IsValid)
            {
                objCargaAcademica.Guardar();
                return Redirect("~/CargaAcademica");
            }
            else
            {
                return View("~/Views/CargaAcademica/Agregar.cshtml");
            }

        }

        //Action Eliminar

        public ActionResult Eliminar(int id)
        {
             objCargaAcademica.Codigo_CargaAcademica = id;
            objCargaAcademica.Eliminar();
            return Redirect("~/CargaAcademica");
        }
    }
}