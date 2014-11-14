namespace CargoSystem.Web.Controllers
{
    using CargoSystem.Data;
    using CargoSystem.Data.Models;
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using System.Web.Routing;

    public class BaseController : Controller
    {
        protected ICargoSystemData Data { get; private set; }

        protected User UserProfile { get; private set; }

        public BaseController(ICargoSystemData data)
        {
            this.Data = data;
        }

        protected override IAsyncResult BeginExecute(RequestContext requestContext, AsyncCallback callback, object state)
        {
            this.UserProfile = this.Data.Users.All().Where(u => u.UserName == requestContext.HttpContext.User.Identity.Name).FirstOrDefault();
            return base.BeginExecute(requestContext, callback, state);
        }
    }
}