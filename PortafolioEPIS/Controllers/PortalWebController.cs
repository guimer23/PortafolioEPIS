using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortafolioEPIS.Controllers
{
    public class PortalWebController : Controller
    {
        // GET: PortalWeb
        public ActionResult Index()
        {
            return View();
        }
    }
}