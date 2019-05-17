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
        //Instanciar la clase Semestre
        private Tbl_Docente objDocente = new Tbl_Docente();

        // Acction Listar
        public ActionResult Index()
        {
            return View(objDocente.Listar());
        }

        //Acction Visualizar
        public ActionResult Visualizar(int id)
        {
            return View(objDocente.Obtener(id));
        }

        // Accion Agregar
        public ActionResult Agregar(int id = 0)
        {
            return View(id == 0 ? new Tbl_Docente() //Agregar un nuevo objeto
               : objDocente.Obtener(id));
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

        //Action Eliminar

        public ActionResult Eliminar(int id)
        {
            objDocente.Codigo_Docente = id;
            objDocente.Eliminar();
            return Redirect("~/Docente");
        }
    }
}