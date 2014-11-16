namespace CargoSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using CargoSystem.Data.Common.Models;

    public class Message : DeletableEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public User Receiver { get; set; }
        
        [Required]
        public User Sender { get; set; }

        [Required]
        [MaxLength(100)]
        [MinLength(2)]
        public string Title { get; set; }
        
        [Required]
        [MaxLength(500)]
        [MinLength(2)]
        public string Body { get; set; }
    }
}
