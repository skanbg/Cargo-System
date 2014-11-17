namespace CargoSystem.Web.Areas.Administration.Controllers
{
    using CargoSystem.Data;
    using CargoSystem.Web.Areas.Administration.Controllers.Base;
    using CargoSystem.Web.Areas.Administration.Helpers;
    using System.Web.Mvc;

    public class AdminController : BaseAdminController
    {
        public AdminController(ICsData data)
            : base(data)
        {
        }

        [ChildActionOnly]
        public ActionResult Menu()
        {
            return this.PartialView("~/Areas/Administration/Views/Shared/_AdminMenu.cshtml", AdminMenu.Items);
        }
    }
}