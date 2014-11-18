namespace CargoSystem.Web.Controllers
{
    using CargoSystem.Data;
    using CargoSystem.Data.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using System.Web.Routing;

    public class BaseController : Controller
    {

        public BaseController(ICsData data)
        {
            this.Data = data;
        }

        protected ICsData Data { get; private set; }

        protected User UserProfile { get; private set; }

        protected override IAsyncResult BeginExecute(RequestContext requestContext, AsyncCallback callback, object state)
        {
            this.UserProfile = this.Data.Users.All().Where(u => u.UserName == requestContext.HttpContext.User.Identity.Name).FirstOrDefault();

            return base.BeginExecute(requestContext, callback, state);
        }

        protected void Notify(string userId, string title, string message, NotificationType type)
        {
            this.Data.Notifications.Add(new Notification()
            {
                UserId = userId,
                Title = title,
                Message = message,
                NotificationType = type
            });
            this.Data.Notifications.SaveChanges();
        }

        protected void Notify(IEnumerable<string> userIds, string title, string message, NotificationType type)
        {
            foreach (var userId in userIds)
            {
                Notify(userId, title, message, type);
            }
        }
    }
}