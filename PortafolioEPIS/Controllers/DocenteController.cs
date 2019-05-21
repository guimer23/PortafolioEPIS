using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PortafolioEPIS.Models;
using System.Data.Entity;
using System.IO;

namespace PortafolioEPIS.Controllers
{
    public class DocenteController : Controller
    {
        //Instanciar la clase 
        private Tbl_Docente objDocente = new Tbl_Docente();
        private Tbl_Profesion objProfesion = new Tbl_Profesion();
        private Tbl_CargoDocente objCargoDocente = new Tbl_CargoDocente();

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



        //Accion Agregar
        
        public ActionResult Agregar(string id="")
        {
            ViewBag.Tbl_Profesion = objProfesion.Listar();
            ViewBag.Tbl_CargoDocente = objCargoDocente.Listar();
            return View(id == "" ? new Tbl_Docente() // Agregar un nuevo objeto
                : objDocente.Obtener(id));
        }
        
        // Action Ver
        public ActionResult Ver(string id ="")
        {
            return View(objDocente.Obtener(id));
        }

        // Action Guardar
        [HttpPost]
        public ActionResult Guardar(Tbl_Docente objDocente, HttpPostedFileBase foto)
        {

            if (foto != null)
            {
                //string archivo = (foto.FileName).ToLower();

                //foto.SaveAs(Server.MapPath("~/Imagen/" + foto.FileName));

                //objDocente.Foto_Docente = foto.FileName;
                string fileName = Path.GetFileName(foto.FileName);

                byte[] bytes = new byte[foto.ContentLength];
                foto.InputStream.Read(bytes, 0, bytes.Length);
                string fileLocationString = "~/Imagen";
                string fileLocation = Path.Combine(Server.MapPath(fileLocationString), fileName);
                if (!Directory.Exists(Server.MapPath(fileLocationString))) Directory.CreateDirectory(Server.MapPath(fileLocationString));
                foto.SaveAs(fileLocation);
                objDocente.Foto_Docente = fileName;
            }

            objDocente.Guardar();
                return Redirect("~/Docente");
            
           

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

        public ActionResult Eliminar(string id)
        {
            objDocente.Codigo_Docente= id;
            objDocente.Eliminar();
            return Redirect("~/Docente");
        }
    }
}
