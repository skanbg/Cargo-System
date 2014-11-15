namespace CargoSystem.Data.Models
{
    using CargoSystem.Data.Common.Models;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Address : DeletableEntity
    {
        [Key]
        public int Id { get; set; }

        [Index]
        public virtual Country Country { get; set; }

        //[MaxLength(30)]
        public string Town { get; set; }

        //[MaxLength(30)]
        public string Street { get; set; }

        //[MaxLength(20)]
        public string Apartment { get; set; }

        //[MaxLength(6)]
        public string PostCode { get; set; }
    }
}
