namespace CargoSystem.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Carrier : User
    {
        private ICollection<Vehicle> vehicles;

        private ICollection<Offer> offers;

        private ICollection<DeclaredRoute> routes;

        public Carrier()
        {
            this.vehicles = new HashSet<Vehicle>();
            this.offers = new HashSet<Offer>();
            this.routes = new HashSet<DeclaredRoute>();
        }

        public virtual ICollection<Vehicle> Vehicles
        {
            get { return this.vehicles; }

            set { this.vehicles = value; }
        }

        public virtual ICollection<Offer> Offers
        {
            get { return this.offers; }

            set { this.offers = value; }
        }

        public virtual ICollection<DeclaredRoute> Routes
        {
            get { return this.routes; }

            set { this.routes = value; }
        }
    }
}
