﻿namespace CargoSystem.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using CargoSystem.Data.Common.Models;
    using CargoSystem.Data.Common.Repository;
    using CargoSystem.Data.Models;
    using CargoSystem.Data.Repositories.Base;

    public class CSData : ICsData
    {
        private readonly DbContext context;

        private readonly Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        public CSData(DbContext context)
        {
            this.context = context;
        }

        public IDeletableEntityRepository<User> Users
        {
            get { return this.GetDeletableEntityRepository<User>(); }
        }

        public IDeletableEntityRepository<Package> Packages
        {
            get { return this.GetDeletableEntityRepository<Package>(); }
        }

        public IDeletableEntityRepository<Offer> Offers
        {
            get { return this.GetDeletableEntityRepository<Offer>(); }
        }

        public IDeletableEntityRepository<Route> Routes
        {
            get { return this.GetDeletableEntityRepository<Route>(); }
        }

        public IDeletableEntityRepository<Country> Countries
        {
            get { return this.GetDeletableEntityRepository<Country>(); }
        }

        public IDeletableEntityRepository<Message> Messages
        {
            get { return this.GetDeletableEntityRepository<Message>(); }
        }

        public IDeletableEntityRepository<Vehicle> Vehicles
        {
            get { return this.GetDeletableEntityRepository<Vehicle>(); }
        }

        public IDeletableEntityRepository<Notification> Notifications
        {
            get { return this.GetDeletableEntityRepository<Notification>(); }
        }

        public IDeletableEntityRepository<Feedback> Feedbacks
        {
            get { return this.GetDeletableEntityRepository<Feedback>(); }
        }

        public DbContext Context
        {
            get
            {
                return this.context;
            }
        }

        /// <summary>
        /// Saves all changes made in this context to the underlying database.
        /// </summary>
        /// <returns>
        /// The number of objects written to the underlying database.
        /// </returns>
        /// <exception cref="T:System.InvalidOperationException">Thrown if the context has been disposed.</exception>
        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        public void Dispose()
        {
            this.Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.context != null)
                {
                    this.context.Dispose();
                }
            }
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(GenericRepository<T>);

                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.context));
            }

            return (IRepository<T>)this.repositories[typeof(T)];
        }

        private IDeletableEntityRepository<T> GetDeletableEntityRepository<T>() where T : class, IDeletableEntity
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(DeletableEntityRepository<T>);
                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.context));
            }
            return (IDeletableEntityRepository<T>)this.repositories[typeof(T)];
        }
    }
}
