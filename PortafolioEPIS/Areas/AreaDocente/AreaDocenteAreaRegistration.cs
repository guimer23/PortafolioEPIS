using System.Web.Mvc;

namespace PortafolioEPIS.Areas.AreaDocente
{
    public class AreaDocenteAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "AreaDocente";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "AreaDocente_default",
                "AreaDocente/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}