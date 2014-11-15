namespace CargoSystem.Data.Models
{
    using CargoSystem.Data.Common.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public class Vehicle : DeletableEntity
    {
        private ICollection<Route> routes;
        public Vehicle()
        {
            this.routes = new HashSet<Route>();
        }

        [Key]
        public int Id { get; set; }

        public virtual User Owner { get; set; }

        public virtual TrailerSize Dimensions { get; set; }

        public virtual ICollection<Route> Routes
        {
            get { return this.routes; }

            set { this.routes = value; }
        }
    }
}
