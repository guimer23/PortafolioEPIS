using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PortafolioEPIS.Models;

namespace PortafolioEPIS.Controllers.Mantenimiento
{
    public class ProfesionController : Controller
    {

        //instanciar la clase
        private Tbl_Profesion objTbl_Profesion = new Tbl_Profesion();
        // GET: Tbl_Profesion
        public ActionResult Index()
        {

            return View(objTbl_Profesion.Listar());

        }

        //accion visualizar
        public ActionResult Visualizar(int id)
        {
            return View(objTbl_Profesion.Obtener(id));
        }

        //acccion agregar editar
        public ActionResult Agregar(int id = 0)
        {

            return View(
                id == 0 ? new Tbl_Profesion() // Agregar un nuevo objeto
                : objTbl_Profesion.Obtener(id)

                );
        }

        //accion Guardar
        public ActionResult Guardar(Tbl_Profesion objTbl_Profesion)
        {
            if (ModelState.IsValid)
            {
                objTbl_Profesion.Guardar();
                return Redirect("~/Profesion");
            }
            else
            {
                return View("~/Views/Profesion/Agregar.cshtml");
            }
        }

        //accion eleiminar
        public ActionResult Eliminar(int id)
        {
            objTbl_Profesion.Codigo_Profesion = id;
            objTbl_Profesion.Eliminar();
            return Redirect("~/Profesion");
        }
    }
}