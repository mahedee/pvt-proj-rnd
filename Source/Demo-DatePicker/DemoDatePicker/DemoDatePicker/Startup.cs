using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DemoDatePicker.Startup))]
namespace DemoDatePicker
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
