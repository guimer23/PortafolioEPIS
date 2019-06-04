using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using PortafolioEPIS.Models;

namespace PortafolioEPIS.Controllers.Informes
{
    public class ConocimientoHabilidadController : Controller
    {
        private Tbl_ConocimientoHabilidad objConocimientoHabilidad = new Tbl_ConocimientoHabilidad();
        private Tbl_PruebaEntrada objPruebaEntrada = new Tbl_PruebaEntrada();
        // Accion Listar
        public ActionResult Index()
        {
            return View(objConocimientoHabilidad.Listar());
        }
        // Accion Agregar
        public ActionResult Agregar(int id = 0)
        {
            ViewBag.Tbl_PruebaEntrada = objPruebaEntrada.Listar();
            return View(id == 0 ? new Tbl_ConocimientoHabilidad()//Agregar un nuevo objeto
               : objConocimientoHabilidad.Obtener(id));
        }

        public ActionResult Guardar(Tbl_ConocimientoHabilidad objConocimientoHabilidad)
        {
            if (ModelState.IsValid)
            {
                objConocimientoHabilidad.Guardar();
                return Redirect("~/ConocimientoHabilidad");
            }
            else
            {
                return View("~/Views/ConocimientoHabilidad/Agregar");
            }

        }
        public ActionResult Eliminar(int id)
        {
            objConocimientoHabilidad.Codigo_ConocimientoHabilidad = id;
            objConocimientoHabilidad.Eliminar();
            return Redirect("~/ConocimientoHabilidad");

        }
    }
}