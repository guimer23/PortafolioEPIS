using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PortafolioEPIS.Models;
using System.Linq;
using System.Data.Entity;

namespace PortafolioEPIS.Controllers
{
    public class DocenteController : Controller
    {
        //Instanciar la clase 
        private Tbl_Docente objDocente = new Tbl_Docente();

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
        Tbl_Profesion db = new Tbl_Profesion();
        [HttpGet]
        public ActionResult Agregar(string id)
        {
            ViewBag.Lista = db.Estado_Profesion.ToString();

            return View();
        }

        // Accion Ver 
        public ActionResult Ver()
        {
            return View();
        }

        //Action Guardar
        //public ActionResult Guardar(Tbl_Docente objDocente)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        objDocente.Guardar();
        //        return Redirect("~/Docente");
        //    }
        //    else
        //    {
        //        return View("~/Views/Docente/Agregar");
        //    }

        //}

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
            return Redirect("~/Semestre");
        }
    }
}