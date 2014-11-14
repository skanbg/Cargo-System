namespace CargoSystem.Web.Controllers
{
    using CargoSystem.Data;
    using CargoSystem.Web.Infrastructure.Services.Contracts;
    using CargoSystem.Web.ViewModels.Home;
    using System.Web.Mvc;

    public class HomeController : BaseController
    {
        private IHomeServices homeServices;

        public HomeController(ICargoSystemData data, IHomeServices homeServices)
            : base(data)
        {
            this.homeServices = homeServices;
        }

        public ActionResult Index()
        {
            var model = new IndexViewModel()
            {
                Carriers = this.homeServices.GetLastRegisteredCarriersViewModel(5),
                Speditors = this.homeServices.GetLastRegisteredSpeditorsViewModel(5)
            };

            return View(model);
        }
    }
}