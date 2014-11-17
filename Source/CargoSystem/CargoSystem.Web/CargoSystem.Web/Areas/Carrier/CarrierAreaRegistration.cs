namespace CargoSystem.Web.Areas.Carrier
{
    using System.Web.Mvc;

    public class CarrierAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Carrier";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
            "Carrier_default",
            "Carrier/{controller}/{action}/{id}",
            new { action = "Index", id = UrlParameter.Optional });
        }
    }
}