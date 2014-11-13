namespace CargoSystem.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Speditor : User
    {
        private ICollection<Offer> proposedOffers;

        private ICollection<Carrier> carriers;

        public Speditor()
        {
            this.proposedOffers = new HashSet<Offer>();
            this.carriers = new HashSet<Carrier>();
        }

        public virtual ICollection<Offer> ProposedOffers
        {
            get { return this.proposedOffers; }

            set { this.proposedOffers = value; }
        }

        public virtual ICollection<Carrier> Carriers
        {
            get { return this.carriers; }

            set { this.carriers = value; }
        }
    }
}
