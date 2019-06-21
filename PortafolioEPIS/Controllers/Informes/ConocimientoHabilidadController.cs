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
        public ActionResult Index(int id1)
        {
            ViewBag.id1 = id1;
            return View(objConocimientoHabilidad.Listar());
        }
        // Accion Agregar
        public ActionResult Agregar(int id = 0)
        {
            ViewBag.Tbl_PruebaEntrada = objPruebaEntrada.Listar();
            return View(id == 0 ? new Tbl_ConocimientoHabilidad()//Agregar un nuevo objeto
               : objConocimientoHabilidad.Obtener(id));
        }

        public ActionResult Guardar(Tbl_ConocimientoHabilidad objConocimientoHabilidad, int idprueba, string nombre, int deficiente, int suficiente, int bueno, int codigo )
        {
           

                objConocimientoHabilidad.Codigo_PruebaEntrada = idprueba;
                objConocimientoHabilidad.Nombre_ConocimientoHabilidad = nombre;
                objConocimientoHabilidad.Deficiente_ConocimientoHabilidad = deficiente;
                objConocimientoHabilidad.Suficiente_ConocimientoHabilidad = suficiente;
                objConocimientoHabilidad.Bueno_ConocimientoHabilidad = bueno;
                objConocimientoHabilidad.Guardar();
                return Redirect("~/PruebaEntrada/Agregar/" + codigo);
           

        }
        public ActionResult Eliminar(int id=0,int cid=0)
        {
            objConocimientoHabilidad.Codigo_ConocimientoHabilidad = id;
            objConocimientoHabilidad.Eliminar();
            return Redirect("~/PruebaEntrada/Agregar/" + cid);

        }
    }
}