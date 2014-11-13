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
            this.PackageState = PackageState.WaitingForBargain;
        }

        [Key]
        public int Id { get; set; }

        public Guid SpeditorId { get; set; }

        public virtual Speditor Speditor { get; set; }

        [Index]
        public PackageState PackageState { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        [Index]
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
