namespace CargoSystem.Data.Models
{
    using CargoSystem.Data.Common.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public class Vehicle : IAuditInfo, IDeletableEntity
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

        [Index]
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool PreserveCreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
