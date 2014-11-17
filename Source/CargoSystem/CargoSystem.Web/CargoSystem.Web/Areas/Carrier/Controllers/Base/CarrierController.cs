namespace CargoSystem.Web.Areas.Carrier.Controllers.Base
{
    using System.Web.Mvc;
    using CargoSystem.Web.Controllers;
    using CargoSystem.Data;
    using CargoSystem.Common;

    [Authorize(Roles = GlobalConstants.CarrierRoleName)]
    public abstract class CarrierController : BaseController
    {
        public CarrierController(ICsData data)
            : base(data)
        {
        }
    }
}