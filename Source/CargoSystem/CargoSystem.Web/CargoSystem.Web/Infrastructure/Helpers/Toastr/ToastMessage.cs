namespace CargoSystem.Web.Infrastructure.Helpers.Toastr
{
    using CargoSystem.Data.Models;
    using System;

    [Serializable]
    public class ToastMessage
    {
        public string Title { get; set; }

        public string Message { get; set; }

        public NotificationType ToastType { get; set; }

        public bool IsSticky { get; set; }
    }
}