﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PortafolioEPIS.Models;

namespace PortafolioEPIS.Controllers.Informes
{
    public class InformeFinalController : Controller
    {
        private Tbl_Observaciones objObservaciones = new Tbl_Observaciones();
        private Tbl_CapacidadesCurso objCapacidadesCurso = new Tbl_CapacidadesCurso();

        private Tbl_InformeFinal objInformeFinal = new Tbl_InformeFinal();
        private Tbl_DetalleCargaAcademica objDetalleCargaAcademica = new Tbl_DetalleCargaAcademica();
        private Tbl_Portafolio objportafolio = new Tbl_Portafolio();
        //Tbl_Observaciones objObservaciones = new Tbl_Observaciones();
        // GET: InformeFinal
        public ActionResult Index()
        {
            return View();
        }
        // Metodo Agregar
        public ActionResult Agregar(int id)
        {
            ViewBag.prueba = objInformeFinal.Listar();
            ViewBag.portafolio = objportafolio.Listar();
            List<Tbl_InformeFinal> listInformeFinal = objInformeFinal.Listar();
            int foerach = 0;


            foreach (var listaInforme in listInformeFinal)
            {
                if (listaInforme.Codigo_DetalleCargaAcademica == id)
                {
                    ViewBag.ListarObservaciones = objObservaciones.Listar1(listaInforme.Codigo_InformeFinal); //obtener la lista deevidencias de un  portafolio
                    foerach++;
                }

            }

            if (foerach == 0)
            {
                ViewBag.ListarInformeFinal = objObservaciones.Listar1(0); //obtener la lista deevidencias de un  portafolio
            }


            // ViewBag.ObtenerEvidencia = objMaterial.ObtenerEvidencia(id);//esto es en el caso de s¿que se agregue modificar
            return View(objDetalleCargaAcademica.Obtener(id));
        }
        // s @Model.Codigo_DetalleCargaAcademica + "&estado=" + stado + "&prorealizados=" + prorealizados + "&matriculados=" + matriculados + "&estretiro=" + estretiro + "&estabandono=" + estabandono + "&estasistentes=" + estasistentes + "&estaprobados=" + estaprobados + "&estdesaprobados=" + estdesaprobados + "&notaalta=" + notaalta + "&notapromedio=" + notapromedio + "&notabaja=" + notabaja;

        public ActionResult Guardar1(Tbl_InformeFinal objInformeFinal, int idprueba, int psilabo, int prarealizadas, int elaboratorio, int codigo, string estado, int prorealizados, int matriculados, int estretiro, int estabandono, int estasistentes, int estaprobados, int estdesaprobados, int notaalta, int notapromedio, int notabaja)
        {

            objInformeFinal.Codigo_InformeFinal = idprueba;
            objInformeFinal.Codigo_DetalleCargaAcademica = codigo;
            objInformeFinal.PorcentajeSilabo_InformeFinal = psilabo;
            objInformeFinal.PracticasCalificadas_InformeFinal = prarealizadas;
            objInformeFinal.LaboratoriosRealizados_InformeFinal = elaboratorio;
            objInformeFinal.TrabajosRealizados_InformeFinal = prorealizados;
            
            objInformeFinal.EstudiantesMatriculados_InformeFinal = matriculados;
            objInformeFinal.EstudiantesRetiro_InformeFinal = estretiro;
            objInformeFinal.EstudiantesAbandono_InformeFinal = estabandono;
            objInformeFinal.EstudiantesAsisten_InformeFinal = estasistentes;
            objInformeFinal.EstudiantesAprobados_InformeFinal = estaprobados;
            objInformeFinal.EstudiantesDesaprobados_InformeFinal = estdesaprobados;
            objInformeFinal.NotaAlta_InformeFinal = notaalta;
            objInformeFinal.NotaPromedio_InformeFinal =notapromedio;
            objInformeFinal.NotaBaja_InformeFinal = notabaja;
            objInformeFinal.Fecha_InformeFinal= DateTime.Now;
            objInformeFinal.Estado_InformeFinal = estado;
            objInformeFinal.Guardar();
            return Redirect("~/InformeFinal/Agregar/" + codigo);
        }

            public ActionResult Ver(int id)
        {
            return View(objInformeFinal.Obtener(id));
        }
        public ActionResult AgregarObservaciones(int idInformeFinal = 0, int idPruebaDoc = 0)
        {
            ViewBag.idInformeFinal = idInformeFinal;
            ViewBag.idPruebaDoc = idPruebaDoc;

            //ViewBag.ListaTbl_MedidasCorrectivas = objlistaMedidasCorrectivas.Listar();
            return View(              
                objObservaciones.Obtener(idInformeFinal)
                );
        }



        //Action Guardar
        public ActionResult GuardarObservaciones(Tbl_Observaciones ObjObservaciones, int idPruebaDoc)
        {
                ObjObservaciones.Guardar();
                return Redirect("~/InformeFinal/Agregar/"+ idPruebaDoc);
        }


        //Action Guardar
        public ActionResult Guardar(Tbl_InformeFinal objInformeFinal)
        {
            if (ModelState.IsValid)
            {
                objInformeFinal.Guardar();
                return Redirect("~/InformeFinal");
            }
            else
            {
                return View("~/Views/InformeFinal/Agregar.cshtml");
            }

        }

        public ActionResult AgregarCapacidadCurso(int idInformeFinal=0,  int idPruebaDoc = 0)
        {
            ViewBag.idInformeFinal = idInformeFinal;
            ViewBag.idPruebaDoc = idPruebaDoc;

            //ViewBag.ListaTbl_MedidasCorrectivas = objlistaMedidasCorrectivas.Listar();
            return View(
                objCapacidadesCurso.ObtenerCapacidades(0)
                );
        }
        //Action Guardar
        public ActionResult GuardarCapacidadCurso(Tbl_CapacidadesCurso ObjCapacidadesCurso, int idPruebaDoc, int radio)
        {
            switch (radio)
            {
                case 1:
                    ObjCapacidadesCurso.Nada_CapacidadesCurso = 1;
                    break;
                case 2:
                    ObjCapacidadesCurso.Poco_CapacidadesCurso = 1;
                    break;
                case 3:
                    ObjCapacidadesCurso.Aceptable_CapacidadesCurso = 1;
                    break;
                case 4:
                    ObjCapacidadesCurso.Bien_CapacidadesCurso = 1;
                    break;
                case 5:
                    ObjCapacidadesCurso.MuyBien_CapacidadesCurso = 1;
                    break;
               
            }


            ObjCapacidadesCurso.Guardar();
            return Redirect("~/InformeFinal/Agregar/" + idPruebaDoc);
        }


        //Action Eliminar

        public ActionResult Eliminar(int id)
        {
            objInformeFinal.Codigo_InformeFinal = id;
            objInformeFinal.Eliminar();
            return Redirect("~/InformeFinal");
        }
    }
}