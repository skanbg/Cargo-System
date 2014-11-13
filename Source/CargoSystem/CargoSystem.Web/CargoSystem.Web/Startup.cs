using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CargoSystem.Web.Startup))]
namespace CargoSystem.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
