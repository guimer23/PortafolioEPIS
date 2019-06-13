using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PortafolioEPIS.Models;

namespace PortafolioEPIS.Controllers.Informes
{
    public class PortafolioU1Controller : Controller
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
            }
            
            objEvidencia.Guardar();
            return Redirect("~/PortafolioU1/Agregar/" + Codigo_detalle_carga);
        }

        public ActionResult Guardar(Tbl_Portafolio objPortafolioU1, int idprueba,int retirados, int abandonos, int aprobados,int codigo,string estado,string unidad)
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
            return Redirect("~/PortafolioU1/Agregar/" + codigo);

            //}
            //else
            //{
            //    return View("~/Views/PruebaEntrada/Agregar.cshtml");
            //}

        }
    }
}