using System.Collections.Generic;
namespace CargoSystem.Web.ViewModels.Notification
{
    public class NotificationsViewModel
    {
        public int UnreadMessages { get; set; }

        public int DelayedDeliveries { get; set; }

        public int CanceledDeliveries { get; set; }

        public int StartedDeliveries { get; set; }
    }
}