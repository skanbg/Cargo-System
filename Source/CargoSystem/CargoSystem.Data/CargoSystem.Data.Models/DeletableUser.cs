namespace CargoSystem.Data.Models
{
    using CargoSystem.Data.Common.Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    public abstract class DeletableUser : IdentityUser, IDeletableEntity, IAuditInfo
    {
        [Index]
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool PreserveCreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
