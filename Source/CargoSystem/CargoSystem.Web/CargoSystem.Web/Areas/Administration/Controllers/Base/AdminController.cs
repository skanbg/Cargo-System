namespace CargoSystem.Web.Areas.Administration.Controllers.Base
{
    using CargoSystem.Common;
    using CargoSystem.Data;
    using CargoSystem.Web.Controllers;
    using System.Web.Mvc;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [ValidateInput(false)]
    public abstract class BaseAdminController : BaseController
    {
        public BaseAdminController(ICargoSystemData data)
            : base(data)
        {
        }
    }
}