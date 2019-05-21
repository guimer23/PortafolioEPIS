using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using PortafolioEPIS.Models;

namespace PortafolioEPIS.Controllers.Mantenimiento
{
    public class CargoController : Controller
    {
        private Tbl_CargoDocente objCargo = new Tbl_CargoDocente();

        // GET: Tbl_CargaAcademica
        public ActionResult Index()
        {

            return View(objCargo.Listar());

        }

        //ACCION VISUALIZAR
        public ActionResult Visualizar(int id)
        {
            return View(objCargo.Obtener(id));
        }

        //ACCION AGREGAR EDITAR 
        public ActionResult Agregar(int id = 0)
        {

            return View(
                id == 0 ? new Tbl_CargoDocente() // Agregar un nuevo objeto
                : objCargo.Obtener(id)

                );
        }

        //ACCION GUARDAR
        public ActionResult Guardar(Tbl_CargoDocente objCargo)
        {
            if (ModelState.IsValid)
            {
                objCargo.Guardar();
                return Redirect("~/Cargo");
            }
            else
            {
                return View("~/Views/Cargo/Agregar.cshtml");
            }
        }

        //ACCION ELIMINAR
        public ActionResult Eliminar(int id)
        {
            objCargo.Codigo_CargoDocente = id;
            objCargo.Eliminar();
            return Redirect("~/Cargo");
        }
    }
}