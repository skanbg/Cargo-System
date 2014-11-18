namespace CargoSystem.Web.Controllers
{
    using System.Web.Mvc;
    using System.Linq;
    using CargoSystem.Data;
    using CargoSystem.Web.Infrastructure.Helpers.Toastr.ControllerExtensions;
    using CargoSystem.Web.Infrastructure.Services.Contracts;
    using CargoSystem.Web.ViewModels.Notification;
    using CargoSystem.Common.Extensions;
    using Microsoft.AspNet.Identity;
    using CargoSystem.Web.Infrastructure.Helpers.Toastr;
    using AutoMapper.QueryableExtensions;

    [Authorize]
    public class NotificationController : BaseController
    {
        private INotificationServices notificationServices;

        public NotificationController(ICsData data, INotificationServices notificationServices)
            : base(data)
        {
            this.notificationServices = notificationServices;
        }

        public ActionResult LoadBar()
        {
            var notifications = this.Data.Notifications.All()
                .Where(n => n.User.Id == this.UserProfile.Id).Take(3);
            foreach (var notification in notifications)
            {
                this.AddToastMessage(notification.Title, notification.Message, notification.NotificationType);
                this.Data.Notifications.Delete(notification);
            }

            if (notifications.Count() > 0)
            {
                this.Data.Notifications.SaveChanges();
            }

            var model = new NotificationsViewModel()
            {
                CanceledDeliveries = this.notificationServices.GetCanceledDeliveriesCount(this.UserProfile.Id),
                DelayedDeliveries = this.notificationServices.GetDelayedDeliveriesCount(this.UserProfile.Id),
                StartedDeliveries = this.notificationServices.GetStartedDeliveriesCount(this.UserProfile.Id),
                UnreadMessages = this.notificationServices.GetIncomeMessagesCount(this.UserProfile.Id),
            };

            return this.PartialView("_NotificationBar", model);
        }
    }
}