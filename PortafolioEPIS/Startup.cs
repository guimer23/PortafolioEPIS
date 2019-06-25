using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PortafolioEPIS.Startup))]
namespace PortafolioEPIS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
