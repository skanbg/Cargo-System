namespace CargoSystem.Web.Areas.Carrier.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public class RoutesController : Controller
    {
        // GET: Carrier/Routes
        public ActionResult Index()
        {
            return View();
        }
    }
}