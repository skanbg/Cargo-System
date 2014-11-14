namespace CargoSystem.Data.Models
{
    using CargoSystem.Data.Common.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Country : IAuditInfo, IDeletableEntity
    {
        private ICollection<Package> packages;
        private ICollection<User> users;

        public Country()
        {
            this.packages = new HashSet<Package>();
            this.users = new HashSet<User>();
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

        [Index]
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool PreserveCreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
