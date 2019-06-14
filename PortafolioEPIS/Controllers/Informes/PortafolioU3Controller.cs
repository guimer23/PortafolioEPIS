using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PortafolioEPIS.Models;
using System.IO;

namespace PortafolioEPIS.Controllers.Informes
{
    public class PortafolioU3Controller : Controller
    {
        private Tbl_DetalleCargaAcademica objDetalleCargaAcademica = new Tbl_DetalleCargaAcademica();
        private Tbl_Portafolio objPortafolio = new Tbl_Portafolio();
        private Tbl_Material objMaterial = new Tbl_Material();
        // Accion Listar
        public ActionResult Index()
        {
            return View();
        }


        // Accion Agregar
        public ActionResult Agregar(int id)
        {
            ViewBag.prueba = objPortafolio.Listar();
            List<Tbl_Portafolio> listPortafolio = objPortafolio.Listar();
            int foerach = 0;


            foreach (var listaportafolio in listPortafolio)
            {
                if (listaportafolio.Codigo_DetalleCargaAcademica == id)
                {
                    ViewBag.ListarEvidencia = objMaterial.Listar(listaportafolio.Codigo_Portafolio); //obtener la lista deevidencias de un  portafolio
                    foerach++;
                }

            }

            if (foerach == 0)
            {
                ViewBag.ListarEvidencia = objMaterial.Listar(0); //obtener la lista deevidencias de un  portafolio
            }


            // ViewBag.ObtenerEvidencia = objMaterial.ObtenerEvidencia(id);//esto es en el caso de s¿que se agregue modificar
            return View(objDetalleCargaAcademica.Obtener(id));
        }

        [HttpPost]
        public ActionResult Evidencia(Tbl_Material objEvidencia, HttpPostedFileBase archivo, int Codigo_detalle_carga)
        {
            if (archivo != null)
            {

                archivo.SaveAs(Server.MapPath("~/Imagen/" + archivo.FileName));
                objEvidencia.Archivo_Material = archivo.FileName;
                objEvidencia.TipoArchivo_Material = Path.GetExtension(archivo.FileName);
                objEvidencia.PesoArchivo_Material = Convert.ToString(Math.Round((Convert.ToDecimal(archivo.ContentLength) / (1024 * 1024)), 2)) + " Mb";
            }

            objEvidencia.Guardar();
            return Redirect("~/PortafolioU3/Agregar/" + Codigo_detalle_carga);
        }

        [HttpPost]
        public ActionResult Evidencia1(Tbl_Material objEvidencia, HttpPostedFileBase archivo1, int Codigo_detalle_carga)
        {
            if (archivo1 != null)
            {

                archivo1.SaveAs(Server.MapPath("~/Imagen/" + archivo1.FileName));
                objEvidencia.Archivo_Material = archivo1.FileName;
                objEvidencia.TipoArchivo_Material = Path.GetExtension(archivo1.FileName);
                objEvidencia.PesoArchivo_Material = Convert.ToString(Math.Round((Convert.ToDecimal(archivo1.ContentLength) / (1024 * 1024)), 2)) + " Mb";
            }

            objEvidencia.Guardar();
            return Redirect("~/PortafolioU3/Agregar/" + Codigo_detalle_carga);
        }

        public ActionResult Guardar(Tbl_Portafolio objPortafolioU1, int idprueba, int retirados, int abandonos, int aprobados, int codigo, string estado, string unidad)
        {

            objPortafolioU1.Codigo_Portafolio = idprueba;
            objPortafolioU1.Codigo_DetalleCargaAcademica = codigo;
            objPortafolioU1.Retirados_Portafolio = retirados;
            objPortafolioU1.Abandono_Portafolio = abandonos;
            objPortafolioU1.Aprobados_Portafolio = aprobados;
            objPortafolioU1.Unidad_Portafolio = unidad;
            objPortafolioU1.Fecha_Portafolio = DateTime.Now;
            objPortafolioU1.Estado_Portafolio = estado;
            objPortafolioU1.Guardar();
            return Redirect("~/PortafolioU3/Agregar/" + codigo);

            //}
            //else
            //{
            //    return View("~/Views/PruebaEntrada/Agregar.cshtml");
            //}

        }
    }
}