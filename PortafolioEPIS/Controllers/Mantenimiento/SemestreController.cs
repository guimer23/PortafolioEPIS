using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PortafolioEPIS.Models;

namespace PortafolioEPIS.Controllers.Mantenimiento
{
    public class SemestreController : Controller
    {
        //Listar
        //Instanciar la clase Semestre
        private Tbl_Semestre objSemestre = new Tbl_Semestre();

        public ActionResult Index()
        {
            return View(objSemestre.Listar());
        }

        //Acction Visualizar

        public ActionResult Visualizar(int id)
        {
            return View(objSemestre.Obtener(id));
        }

        // Accion Agregar
        public ActionResult Agregar(int id = 0)
        {
            return View(id == 0 ? new Tbl_Semestre()//Agregar un nuevo objeto
               : objSemestre.Obtener(id));
        }
        //public ActionResult Editar(int id = 0)
        //{
        //    return View(id == 0 ? new Tbl_Semestre()//Agregar un nuevo objeto
        //        : objSemestre.Obtener(id));
        //}

        //Action Guardar
        public ActionResult Guardar(Tbl_Semestre objSemestre)
        {
            if (ModelState.IsValid)
            {
                objSemestre.Guardar();
                return Redirect("~/Semestre");
            }
            else
            {
                return View("~/Views/Semestre/Agregar");
            }

        }

        //Action Eliminar

        public ActionResult Eliminar(int id)
        {
            objSemestre.Codigo_Semestre = id;
            objSemestre.Eliminar();
            return Redirect("~/Semestre");
        }
    }
}