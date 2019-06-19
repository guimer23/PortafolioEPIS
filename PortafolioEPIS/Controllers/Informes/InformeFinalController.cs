using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PortafolioEPIS.Models;

namespace PortafolioEPIS.Controllers.Informes
{
    public class InformeFinalController : Controller
    {

        Tbl_InformeFinal objInformeFinal = new Tbl_InformeFinal();
        // GET: InformeFinal
        public ActionResult Index()
        {
            return View();
        }
        // Metodo Agregar
        public ActionResult Agregar()
        {
            return View();
        }

        public ActionResult Ver(int id)
        {
            return View(objInformeFinal.Obtener(id));
        }

        // Accion Agregar
        public ActionResult Agregar(int id = 0)
        {
            ViewBag.Tbl_Semestre = objInformeFinal.Listar();

            return View(id == 0 ? new Tbl_InformeFinal()//Agregar un nuevo objeto
               : objInformeFinal.Obtener(id));
        }

        //Action Guardar
        public ActionResult Guardar(Tbl_InformeFinal objInformeFinal)
        {
            if (ModelState.IsValid)
            {
                objInformeFinal.Guardar();
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
            objInformeFinal.Codigo_InformeFinal = id;
            objInformeFinal.Eliminar();
            return Redirect("~/CargaAcademica");
        }
    }
}