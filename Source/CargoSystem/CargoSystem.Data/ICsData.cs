namespace CargoSystem.Data
{
    using CargoSystem.Data.Common.Repository;
    using CargoSystem.Data.Models;
    using CargoSystem.Data.Repositories.Base;
    using System;
    using System.Data.Entity;

    public interface ICsData : IDisposable
    {
        DbContext Context { get; }

        IDeletableEntityRepository<User> Users { get; }

        IDeletableEntityRepository<Package> Packages { get; }

        IDeletableEntityRepository<Offer> Offers { get; }

        IDeletableEntityRepository<Route> Routes { get; }

        IDeletableEntityRepository<Country> Countries { get; }

        IDeletableEntityRepository<Message> Messages { get; }

        IDeletableEntityRepository<Vehicle> Vehicles { get; }

        IDeletableEntityRepository<Notification> Notifications { get; }

        IDeletableEntityRepository<Feedback> Feedbacks { get; }

        void Dispose();

        int SaveChanges();
    }
}
