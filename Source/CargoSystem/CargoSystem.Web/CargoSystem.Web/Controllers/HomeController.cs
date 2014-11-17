namespace CargoSystem.Web.Controllers
{
    using System.Web.Mvc;
    using CargoSystem.Data;
    using CargoSystem.Web.Infrastructure.Services.Contracts;
    using CargoSystem.Web.ViewModels.Home;

    public class HomeController : BaseController
    {
        private IHomeServices homeServices;

        public HomeController(ICsData data, IHomeServices homeServices)
            : base(data)
        {
            this.homeServices = homeServices;
        }

        public ActionResult Index()
        {
            var model = new IndexViewModel()
            {
                Routes = this.homeServices.GetLastRoutes(5)
            };

            return this.View(model);
        }

        [ChildActionOnly]
        [OutputCache(Duration = 6 * 10 * 60)]
        public ActionResult Carriers()
        {
            var carriers = this.homeServices.GetLastRegisteredCarriersViewModel(5);
            return this.PartialView("_CarriersTable", carriers);
        }

        [ChildActionOnly]
        [OutputCache(Duration = 6 * 10 * 60)]
        public ActionResult Speditors()
        {
            var speditors = this.homeServices.GetLastRegisteredSpeditorsViewModel(5);
            return this.PartialView("_SpeditorsTable", speditors);
        }
    }
}