﻿namespace CargoSystem.Data.Repositories.Base
{
    using System.Data.Entity;
    using System.Linq;
    using CargoSystem.Data.Common.Models;
    using CargoSystem.Data.Common.Repository;

    public class DeletableEntityRepository<T> : GenericRepository<T>, IDeletableEntityRepository<T>
        where T : class, IDeletableEntity
    {
        public DeletableEntityRepository(DbContext context)
            : base(context)
        {
        }

        public override IQueryable<T> All()
        {
            return base.All().Where(x => !x.IsDeleted);
        }

        public IQueryable<T> AllWithDeleted()
        {
            return base.All();
        }
    }
}
