using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PortafolioEPIS.Models;

namespace PortafolioEPIS.Controllers.Informes
{
    public class MedidasCorrectivasController : Controller
    {
        private Tbl_MedidasCorrectivas objlistaMedidasCorrectivas = new Tbl_MedidasCorrectivas();
        // GET: MedidasCorrectivas
        public ActionResult Index(int id1, int id2)
        {
            ViewBag.IdPruebaEntrada = id1;
            ViewBag.IdDetalleCargaAcademica = id2;

            ViewBag.ListaTbl_MedidasCorrectivas = objlistaMedidasCorrectivas.Listar();
            return View(objlistaMedidasCorrectivas.Obtener(id1));
        }
        public ActionResult Guardar(Tbl_MedidasCorrectivas objMedidasCorrectivas,int IdDetalleCargaAcademica)
        {
            
            if(objMedidasCorrectivas.Medida6_MedidasCorrectivas == false)
            {
                objMedidasCorrectivas.Medida7_MedidasCorrectivas = null;
            }
                objMedidasCorrectivas.Guardar();
                return Redirect("~/PruebaEntrada/Agregar/" + IdDetalleCargaAcademica);
           

        }

    }
}