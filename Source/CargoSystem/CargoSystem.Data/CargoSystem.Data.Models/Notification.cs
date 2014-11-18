namespace CargoSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using CargoSystem.Data.Common.Models;

    public class Notification : DeletableEntity
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Message { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        public NotificationType NotificationType { get; set; }
    }
}
