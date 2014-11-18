namespace CargoSystem.Data
{
    using System.Data.Entity;
    using CargoSystem.Data.Common.Repository;
    using CargoSystem.Data.Models;

    public interface ICargoSystemData
    {
        DbContext Context { get; }

        IRepository<User> Users { get; }

        IRepository<Package> Packages { get; }

        IRepository<Offer> Offers { get; }

        IRepository<Route> Routes { get; }

        IRepository<Country> Countries { get; }

        IRepository<Message> Messages { get; }

        IRepository<Vehicle> Vehicles { get; }

        IRepository<Notification> Notifications { get; }

        IRepository<Feedback> Feedbacks { get; }

        void Dispose();

        int SaveChanges();
    }
}
