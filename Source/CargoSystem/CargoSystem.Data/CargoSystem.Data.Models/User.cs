namespace CargoSystem.Data.Models
{
    using Microsoft.AspNet.Identity;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Security.Claims;
    using System.Threading.Tasks;

    // You can add profile data for the user by adding more properties to your User class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class User : DeletableUser
    {
        private ICollection<Vehicle> vehicles;
        private ICollection<Offer> offers;
        private ICollection<Route> routes;
        private ICollection<Offer> proposedOffers;
        private ICollection<Message> messages;

        public User()
        {
            this.CreatedOn = DateTime.Now;
            this.vehicles = new HashSet<Vehicle>();
            this.offers = new HashSet<Offer>();
            this.routes = new HashSet<Route>();
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

        public bool IsCarrier { get; set; }

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

        public virtual ICollection<Route> Routes
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

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
