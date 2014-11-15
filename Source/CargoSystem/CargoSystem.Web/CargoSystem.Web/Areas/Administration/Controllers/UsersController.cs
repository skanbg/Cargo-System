namespace CargoSystem.Web.Areas.Administration.Controllers
{
    using AutoMapper;
    using CargoSystem.Data;
    using CargoSystem.Web.Areas.Administration.ViewModels.Users;
    using CargoSystem.Web.Infrastructure.Services.Contracts.Admin;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using System.Web.Mvc;

    public class UsersController : AdminController
    {
        private IHomeServices homeServices;

        public UsersController(ICargoSystemData data, IHomeServices homeServices)
            : base(data)
        {
            this.homeServices = homeServices;
        }

        // GET: Administration/Users
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ReadUsers([DataSourceRequest]DataSourceRequest request)
        {
            var usersDataSource = this.Data.Users.All()
                .ToDataSourceResult(request, user => Mapper.Map<UserViewModel>(user));

            return this.Json(usersDataSource);
        }

        [HttpPost]
        public ActionResult UpdateUser([DataSourceRequest]DataSourceRequest request, UserViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                var user = this.Data.Users.GetById(model.Id);
                Mapper.Map(model, user);
                this.Data.SaveChanges();
            }

            return this.Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        [HttpPost]
        public ActionResult DestroyUser([DataSourceRequest]DataSourceRequest request, UserViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                this.Data.Users.Delete(model.Id);
                this.Data.SaveChanges();
            }

            return this.Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }
    }
}