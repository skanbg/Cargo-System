namespace CargoSystem.Data.Models
{
    using CargoSystem.Data.Common.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Package : IAuditInfo, IDeletableEntity
    {
        private ICollection<Offer> offers;
        public Package()
        {
            this.PackageState = PackageState.WaitingForBargain;
            this.offers = new HashSet<Offer>();
        }

        [Key]
        public int Id { get; set; }

        public virtual User Speditor { get; set; }

        [Index]
        public PackageState PackageState { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        public virtual Address SenderAddress { get; set; }

        public virtual Address ReceiverAddress { get; set; }

        public virtual ICollection<Offer> Offers
        {
            get { return this.offers; }

            set { this.offers = value; }
        }

        [Index]
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool PreserveCreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
