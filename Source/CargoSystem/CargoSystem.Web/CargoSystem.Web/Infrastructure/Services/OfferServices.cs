namespace CargoSystem.Web.Infrastructure.Services
{
    using AutoMapper.QueryableExtensions;
    using CargoSystem.Data;
    using CargoSystem.Web.Infrastructure.Services.Base;
    using CargoSystem.Web.Infrastructure.Services.Contracts;
    using CargoSystem.Web.ViewModels.Offer;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class OfferServices : BaseServices, IOfferServices
    {
        public OfferServices(ICargoSystemData data)
            : base(data)
        {
        }

        public IList<RouteViewModel> GetLastRoutes(int numberOfRoutes)
        {
            var routesViewModel = this.Data
                .Routes
            .All()
            .OrderByDescending(u => u.CreatedOn)
            .Take(numberOfRoutes)
            .Project()
            .To<RouteViewModel>()
            .ToList();

            return routesViewModel;
        }
    }
}