namespace CargoSystem.Data.Models
{
    using CargoSystem.Data.Common.Models;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Offer : IAuditInfo, IDeletableEntity
    {
        [Key]
        public int Id { get; set; }

        public decimal Price { get; set; }

        public virtual User Carrier { get; set; }

        public virtual Package Package { get; set; }

        public virtual Route Route { get; set; }

        public virtual User Speditor { get; set; }

        public OfferStatus OfferStatus { get; set; }

        [Index]
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool PreserveCreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
