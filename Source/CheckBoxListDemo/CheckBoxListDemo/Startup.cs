using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CheckBoxListDemo.Startup))]
namespace CheckBoxListDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
