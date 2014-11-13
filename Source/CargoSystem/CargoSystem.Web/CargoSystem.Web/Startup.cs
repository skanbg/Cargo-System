namespace CargoSystem.Web
{
    using Microsoft.Owin;
    using Owin;
    [assembly: OwinStartupAttribute(typeof(CargoSystem.Web.Startup))]

    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
