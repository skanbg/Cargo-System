namespace CargoSystem.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public class Vehicle
    {
        private ICollection<DeclaredRoute> routes;
        public Vehicle()
        {
            this.routes = new HashSet<DeclaredRoute>();
        }

        [Key]
        public int Id { get; set; }

        public virtual Carrier Owner { get; set; }

        public virtual TrailerSize Dimensions { get; set; }

        public virtual ICollection<DeclaredRoute> Routes
        {
            get { return this.routes; }

            set { this.routes = value; }
        }
    }
}
