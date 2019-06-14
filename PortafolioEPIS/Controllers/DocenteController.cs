using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PortafolioEPIS.Models;
using System.Data.Entity;
using System.IO;
using Microsoft.Reporting.WebForms;

namespace PortafolioEPIS.Controllers
{
    public class DocenteController : Controller
    {
        //Instanciar la clase 
        private Tbl_Docente objDocente = new Tbl_Docente();
        private Tbl_Profesion objProfesion = new Tbl_Profesion();
        private Tbl_CargoDocente objCargoDocente = new Tbl_CargoDocente();
        private Tbl_DetalleCargaAcademica objDetalleCargaAcademica = new Tbl_DetalleCargaAcademica();

        Modelo_Portafolio db = new Modelo_Portafolio();

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

        public ActionResult VistaCursosDocente(int id)
        {
            ViewBag.id = id;
            return View(objDetalleCargaAcademica.Listar());
        }

        public ActionResult VistaCursosTabla(int id)
        {
            ViewBag.id = id;
            return View(objDetalleCargaAcademica.Listar());
        }

        //Accion Agregar

        public ActionResult Agregar(int id=0)
        {
            ViewBag.Tbl_Profesion = objProfesion.Listar();
            ViewBag.Tbl_CargoDocente = objCargoDocente.Listar();
            return View(id == 0? new Tbl_Docente() // Agregar un nuevo objeto
                : objDocente.Obtener(id));
        }
        
        // Action Ver
        public ActionResult Ver(int id =0)
        {
            return View(objDocente.Obtener(id));
        }

       // Action Guardar
        public ActionResult Guardar(Tbl_Docente objDocente, HttpPostedFileBase foto)
        {
            if (ModelState.IsValid)
            {

                if (foto != null)
                {
                    string archivo = (foto.FileName).ToLower();

                    foto.SaveAs(Server.MapPath("~/Imagen/" + foto.FileName));
                    objDocente.Foto_Docente = foto.FileName;
                }

                objDocente.Guardar();
                return Redirect("~/Docente");
            }
            else
            {
                return View("~/Views/Docente/Agregar.cshtml");
            }  

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

        public ActionResult Eliminar(int id)
        {
            objDocente.Codigo_Docente= id;
            objDocente.Eliminar();
            return Redirect("~/Docente");
        }

        //Generar Reportes PDF

        public ActionResult Reports(string ReportType)
        {
            LocalReport localreport = new LocalReport();
            localreport.ReportPath = Server.MapPath("~/Reports/ReporteDocentes.rdlc");

            ReportDataSource reportDataSource = new ReportDataSource();
            reportDataSource.Name = "CargoDocenteDataSet1";
            reportDataSource.Value = db.Tbl_Docente.ToList();
            localreport.DataSources.Add(reportDataSource);
            string reportType = ReportType;
            string mimeType;
            string encoding;
            string fileNameExtension;

            if (reportType == "Excel")
            {
                fileNameExtension = "xlsx";
            }
            else if (reportType == "Word")
            {
                fileNameExtension = "docx";
            }
            else if (reportType == "PDF")
            {
                fileNameExtension = "pdf";
            }
            else
            {
                fileNameExtension = "jpg";
            }

            string[] streams;
            Warning[] warnings;
            byte[] renderedByte;
            renderedByte = localreport.Render(reportType, "", out mimeType, out encoding, out fileNameExtension
                , out streams, out warnings);
            Response.AddHeader("content-disposition", "attachment;filename= Cargo_Docentes." + fileNameExtension);
            return File(renderedByte, fileNameExtension);
        }

    }
}
