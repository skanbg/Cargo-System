namespace CargoSystem.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Address
    {
        [Key]
        public int Id { get; set; }

        [Index]
        public virtual Country Country { get; set; }

        public string Town { get; set; }

        public string Street { get; set; }

        public string Apartment { get; set; }

        public string PostCode { get; set; }
    }
}
