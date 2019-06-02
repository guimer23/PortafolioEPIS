using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PortafolioEPIS.Models;

namespace PortafolioEPIS.Controllers.Mantenimiento
{
    public class SeccionController : Controller
    {
        private Tbl_Seccion objSeccion = new Tbl_Seccion();
        // Accion Listar
        public ActionResult Index()
        {
            return View(objSeccion.Listar());
        }
        // Accion Agregar
        public ActionResult Agregar(int id = 0)
        {
            return View(id == 0 ? new Tbl_Seccion()//Agregar un nuevo objeto
               : objSeccion.Obtener(id));
        }

        public ActionResult Guardar(Tbl_Seccion objSeccion)
        {
            if (ModelState.IsValid)
            {
                objSeccion.Guardar();
                return Redirect("~/Seccion");
            }
            else
            {
                return View("~/Views/Seccion/Agregar");
            }

        }
        public ActionResult Eliminar(int id)
        {
            objSeccion.Codigo_Seccion = id;
            objSeccion.Eliminar();
            return Redirect("~/Seccion");

        }
    }
}