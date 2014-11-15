namespace CargoSystem.Data.Models
{
    using CargoSystem.Data.Common.Models;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Offer : DeletableEntity
    {
        [Key]
        public int Id { get; set; }

        public decimal Price { get; set; }

        public virtual User Carrier { get; set; }

        public virtual Package Package { get; set; }

        public virtual Route Route { get; set; }

        public virtual User Speditor { get; set; }

        public OfferStatus OfferStatus { get; set; }
    }
}
