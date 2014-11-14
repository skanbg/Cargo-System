namespace CargoSystem.Data.Models
{
    using CargoSystem.Data.Common.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Security.Claims;
    using System.Threading.Tasks;

    // You can add profile data for the user by adding more properties to your User class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class User : IdentityUser, IAuditInfo, IDeletableEntity
    {
        private ICollection<Vehicle> vehicles;
        private ICollection<Offer> offers;
        private ICollection<DeclaredRoute> routes;
        private ICollection<Offer> proposedOffers;
        private ICollection<Message> messages;

        public User()
        {
            this.CreatedOn = DateTime.Now;
            this.vehicles = new HashSet<Vehicle>();
            this.offers = new HashSet<Offer>();
            this.routes = new HashSet<DeclaredRoute>();
            this.proposedOffers = new HashSet<Offer>();
            this.messages = new HashSet<Message>();
        }

        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string MiddleName { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string LastName { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string PhoneNumber { get; set; }

        public bool isCarrier { get; set; }

        public virtual ICollection<Vehicle> Vehicles
        {
            get { return this.vehicles; }

            set { this.vehicles = value; }
        }

        public virtual ICollection<Offer> Offers
        {
            get { return this.offers; }

            set { this.offers = value; }
        }

        public virtual ICollection<DeclaredRoute> Routes
        {
            get { return this.routes; }

            set { this.routes = value; }
        }

        public virtual ICollection<Offer> ProposedOffers
        {
            get { return this.proposedOffers; }

            set { this.proposedOffers = value; }
        }

        public virtual ICollection<Message> Messages
        {
            get { return this.messages; }

            set { this.messages = value; }
        }

        [Index]
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool PreserveCreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
