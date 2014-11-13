namespace CargoSystem.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class DeclaredRoute
    {
        private ICollection<Offer> offers;
        public DeclaredRoute()
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

        public virtual Carrier Carrier { get; set; }

        [Index]
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public virtual ICollection<Offer> Offers
        {
            get { return this.offers; }

            set { this.offers = value; }
        }
    }
}
