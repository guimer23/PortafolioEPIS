using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PortafolioEPIS.Models;
using System.Data.Entity;

namespace PortafolioEPIS.Controllers
{
    public class DocenteController : Controller
    {
        //Instanciar la clase 
        private Tbl_Docente objDocente = new Tbl_Docente();
        private Tbl_Profesion objProfesion = new Tbl_Profesion();
        private Tbl_CargoDocente objCargoDocente = new Tbl_CargoDocente();

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



        //Accion Agregar
        
        public ActionResult Agregar(string id="")
        {
            ViewBag.Tbl_Profesion = objProfesion.Listar();
            ViewBag.Tbl_CargoDocente = objCargoDocente.Listar();
            return View(id == "" ? new Tbl_Docente() // Agregar un nuevo objeto
                : objDocente.Obtener(id));
        }
        
        // Action Ver
        public ActionResult Ver(string id ="")
        {
            return View(objDocente.Obtener(id));
        }

       // Action Guardar
        public ActionResult Guardar(Tbl_Docente objDocente)
        {
            
                objDocente.Guardar();
                return Redirect("~/Docente");
            
           

        }

        ////Acction Buscar
        //public ActionResult Buscar(string criterio)
        //{
        //    return View(
        //        criterio == null || criterio == ""
        //        ? objDocente.Listar()
        //        : objDocente.Buscar(criterio)
        //        );
        //}

        //Action Eliminar

        public ActionResult Eliminar(string id)
        {
            objDocente.Codigo_Docente= id;
            objDocente.Eliminar();
            return Redirect("~/Docente");
        }
    }
}
