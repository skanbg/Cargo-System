using CargoSystem.Data;
using CargoSystem.Data.Common.Repository;
using CargoSystem.Data.Models;
using CargoSystem.Data.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CargoSystem.Web.Controllers
{
    public class HomeController : Controller
    {
        private IRepository<Package> packages;

        public HomeController()
            : this(new GenericRepository<Package>(new ApplicationDbContext()))
        {
        }

        public HomeController(IRepository<Package> packages)
        {
            this.packages = packages;
        }

        public ActionResult Index()
        {
            var packages = this.packages.All();
            return View(packages);
        }
    }
}