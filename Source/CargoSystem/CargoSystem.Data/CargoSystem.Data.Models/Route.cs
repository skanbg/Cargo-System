namespace CargoSystem.Data.Models
{
    using CargoSystem.Data.Common.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Route : DeletableEntity
    {
        private ICollection<Offer> offers;

        public Route()
        {
            this.offers = new HashSet<Offer>();
        }

        [Key]
        public int Id { get; set; }

        public virtual Address StartPoint { get; set; }

        public virtual Address EndPoint { get; set; }

        public DateTime? TransportStartDate { get; set; }

        public DateTime? TransportEndDate { get; set; }

        public virtual Vehicle Vehicle { get; set; }

        public virtual User Carrier { get; set; }

        public virtual ICollection<Offer> Offers
        {
            get { return this.offers; }

            set { this.offers = value; }
        }
    }
}
