namespace CargoSystem.Data
{
    using CargoSystem.Data.Common.Repository;
    using CargoSystem.Data.Models;
    using System.Data.Entity;

    public interface ICargoSystemData
    {
        DbContext Context { get; }

        IRepository<User> Users { get; }

        void Dispose();

        int SaveChanges();
    }
}
