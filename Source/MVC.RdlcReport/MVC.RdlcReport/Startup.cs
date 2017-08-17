using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC.RdlcReport.Startup))]
namespace MVC.RdlcReport
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
