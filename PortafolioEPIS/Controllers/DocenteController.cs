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
        // Accion Listar
        public ActionResult Index()
        {
            return View(objDocente.Listar());
        }
        // Accion Listar Mosaico
        public ActionResult Index2()
        {
            return View(objDocente.Listar2());
        }

        // Accion Agregar
        public ActionResult Agregar(int id=0)
        {
            return View(id == 0 ? new Tbl_Docente()//Agregar un nuevo objeto
               : objDocente.Obtener(id));
        }

        // Accion Ver
        public ActionResult Ver()
        {
            return View();
        }

        //Action Guardar
        public ActionResult Guardar(Tbl_Docente objDocente)
        {
            if (ModelState.IsValid)
            {
                objDocente.Guardar();
                return Redirect("~/Docente");
            }
            else
            {
                return View("~/Views/Docente/Agregar");
            }

        }

        //Acction Buscar
        public ActionResult Buscar(string criterio)
        {
            return View(
                criterio == null || criterio == ""
                ? objDocente.Listar()
                : objDocente.Buscar(criterio)
                );
        }

        //Action Eliminar

        public ActionResult Eliminar(int id)
        {
            objDocente.id = id;
            objDocente.Eliminar();
            return Redirect("~/Semestre");
        }
    }
}