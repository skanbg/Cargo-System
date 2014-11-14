namespace CargoSystem.Data
{
    using CargoSystem.Data.Common.Repository;
    using CargoSystem.Data.Models;
    using System.Data.Entity;

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

        void Dispose();

        int SaveChanges();
    }
}
