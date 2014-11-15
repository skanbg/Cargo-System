namespace CargoSystem.Web.Areas.Administration.Controllers.Base
{
    using CargoSystem.Data;
    using CargoSystem.Web.Controllers;
    using System.Web.Mvc;

    [Authorize(Roles="Admin")]
    public abstract class AdminController : BaseController
    {
        public AdminController(ICargoSystemData data)
            : base(data)
        {
        }
    }
}