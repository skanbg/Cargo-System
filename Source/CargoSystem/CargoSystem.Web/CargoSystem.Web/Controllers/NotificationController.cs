namespace CargoSystem.Web.Controllers
{
    using System.Web.Mvc;
    using CargoSystem.Data;
    using CargoSystem.Web.Infrastructure.Services.Contracts;
    using CargoSystem.Web.ViewModels.Notification;
    using Microsoft.AspNet.Identity;

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
            var model = new NotificationsViewModel()
            {
                CanceledDeliveries = this.notificationServices.GetCanceledDeliveriesCount(this.UserProfile.Id),
                DelayedDeliveries = this.notificationServices.GetDelayedDeliveriesCount(this.UserProfile.Id),
                StartedDeliveries = this.notificationServices.GetStartedDeliveriesCount(this.UserProfile.Id),
                UnreadMessages = this.notificationServices.GetIncomeMessagesCount(this.UserProfile.Id)
            };

            return this.PartialView("_NotificationBar", model);
        }
    }
}