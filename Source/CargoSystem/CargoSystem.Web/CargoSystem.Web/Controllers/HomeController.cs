namespace CargoSystem.Web.Controllers
{
    using CargoSystem.Data;
    using CargoSystem.Data.Common.Repository;
    using CargoSystem.Data.Models;
    using CargoSystem.Data.Repositories.Base;
    using CargoSystem.Web.ViewModels;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using AutoMapper.QueryableExtensions;

    public class HomeController : Controller
    {
        private IRepository<Carrier> carriers;

        public HomeController(IRepository<Carrier> carriers)
        {
            this.carriers = carriers;
        }

        public ActionResult Index()
        {
            var carriers = this.carriers.All().Project().To<IndexCarrierViewModel>();
            return View(carriers);
        }
    }
}