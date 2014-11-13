namespace CargoSystem.Data.Models
{
    using CargoSystem.Data.Common.Models;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Package : AuditInfo, IDeletableEntity
    {
        public Package()
        {
            this.Id = new Guid();
            this.PackageState = PackageState.WaitingForBargain;
        }

        [Key]
        public Guid Id { get; set; }

        public Guid SenderId { get; set; }

        public User Sender { get; set; }

        public PackageState PackageState { get; set; }

        [Index]
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
