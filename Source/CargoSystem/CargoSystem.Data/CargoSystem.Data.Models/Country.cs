namespace CargoSystem.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Country
    {
        private ICollection<Package> packages;

        private ICollection<Carrier> carriers;

        private ICollection<Speditor> speditors;

        public Country()
        {
            this.packages = new HashSet<Package>();
            this.carriers = new HashSet<Carrier>();
            this.speditors = new HashSet<Speditor>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(52)] //GB is the longest
        public string Name { get; set; }

        public string PhoneCode { get; set; }

        public virtual ICollection<Package> Packages
        {
            get { return this.packages; }

            set { this.packages = value; }
        }

        public virtual ICollection<Carrier> Carriers
        {
            get { return this.carriers; }

            set { this.carriers = value; }
        }

        public virtual ICollection<Speditor> Speditors
        {
            get { return this.speditors; }

            set { this.speditors = value; }
        }
    }
}
