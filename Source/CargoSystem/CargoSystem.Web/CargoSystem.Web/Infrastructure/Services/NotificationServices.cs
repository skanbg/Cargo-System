namespace CargoSystem.Web.Infrastructure.Services
{
    using System;
    using System.Linq;
    using CargoSystem.Web.Infrastructure.Services.Base;
    using CargoSystem.Web.Infrastructure.Services.Contracts;
    using CargoSystem.Data.Models;
    using CargoSystem.Data;

    public class NotificationServices : BaseServices, INotificationServices
    {
        public NotificationServices(ICargoSystemData data)
            : base(data)
        {
        }

        public int GetIncomeMessagesCount(string userId)
        {
            return this.Data.Messages.All().Where(m => m.Receiver.Id == userId && m.MessageStatus == MessageStatus.Unread).Count();
        }

        public int GetDelayedDeliveriesCount(string userId)
        {
            return 0;
        }

        public int GetStartedDeliveriesCount(string userId)
        {
            return 0;
        }

        public int GetCanceledDeliveriesCount(string userId)
        {
            return 0;
        }
    }
}