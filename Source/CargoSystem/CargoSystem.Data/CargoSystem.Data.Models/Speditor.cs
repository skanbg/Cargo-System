namespace CargoSystem.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Speditor : User
    {
        private ICollection<Carrier> carriers;

        public Speditor()
        {
            this.proposedOffers = new HashSet<й>();
        }

        public virtual ICollection<Carrier> Carriers
        {
            get { return this.carriers; }

            set { this.carriers = value; }
        }
    }
}
