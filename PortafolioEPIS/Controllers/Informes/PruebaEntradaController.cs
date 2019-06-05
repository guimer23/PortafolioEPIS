﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PortafolioEPIS.Models;

namespace PortafolioEPIS.Controllers.Informes
{

   

    public class PruebaEntradaController : Controller
    {
        private Tbl_DetalleCargaAcademica objDetalleCargaAcademica = new Tbl_DetalleCargaAcademica();
        private Tbl_PruebaEntrada objPruebaEntrada = new Tbl_PruebaEntrada();
        private Tbl_PlanEstudio objPlanEstudio = new Tbl_PlanEstudio();
        private Tbl_Docente objDocente = new Tbl_Docente();
        private Tbl_Seccion objSeccion = new Tbl_Seccion();
        private Tbl_DetallePlanEstudio objDetallePlanEstudio = new Tbl_DetallePlanEstudio();
        private Tbl_Semestre objSemestre = new Tbl_Semestre();
        // Accion Listar
        public ActionResult Index()
        {
            return View(objPruebaEntrada.Listar());
        }

        public ActionResult Ver(int id)
        {
            return View(objPruebaEntrada.Obtener(id));
        }
        public ActionResult IndexAdmin()
        {
            return View();
        }
        //Action Guardar
        public ActionResult Guardar(Tbl_PruebaEntrada objPruebaEntrada, int evaluados, int codigo, string estado)
        {
            //if (ModelState.IsValid)
            //{
                objPruebaEntrada.Codigo_DetalleCargaAcademica = codigo;
                objPruebaEntrada.Evaluados_PruebaEntrada = evaluados;
                objPruebaEntrada.Fecha_PruebaEntrada = DateTime.Now;
                objPruebaEntrada.Estado_PruebaEntrada = estado;
                objPruebaEntrada.Guardar();
                return Redirect("~/PruebaEntrada/Agregar/"+codigo);
            //}
            //else
            //{
            //    return View("~/Views/PruebaEntrada/Agregar.cshtml");
            //}

        }

        //Action Eliminar

        public ActionResult Eliminar(int id)
        {
            objPruebaEntrada.Codigo_PruebaEntrada = id;
            objPruebaEntrada.Eliminar();
            return Redirect("~/CargaAcademica");
        }
        //public ActionResult Agregar(int id = 0)
        //{
        //    ViewBag.Tbl_Semestre = objSemestre.Listar();

        //    return View(id == 0 ? new Tbl_PruebaEntrada()//Agregar un nuevo objeto
        //       : objPruebaEntrada.Obtener(id));
        //}
        // Accion Agregar
        public ActionResult Agregar(int id)
        {
            return View(objDetalleCargaAcademica.Obtener(id));
        }
    }
}