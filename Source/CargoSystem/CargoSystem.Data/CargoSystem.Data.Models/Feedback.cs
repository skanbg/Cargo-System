namespace CargoSystem.Data.Models
{
    using CargoSystem.Data.Common.Models;
    using System.ComponentModel.DataAnnotations;

    public class Feedback : DeletableEntity
    {
        public int Id { get; set; }

        [MaxLength(20)]
        public string Title { get; set; }

        [MaxLength(1000)]
        public string Content { get; set; }

        public string AuthorId { get; set; }

        public virtual User Author { get; set; }
    }
}
