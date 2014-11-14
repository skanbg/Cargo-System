namespace CargoSystem.Web.Infrastructure.Services
{
    using AutoMapper.QueryableExtensions;
    using CargoSystem.Data;
    using CargoSystem.Data.Models;
    using CargoSystem.Web.Infrastructure.Services.Base;
    using CargoSystem.Web.Infrastructure.Services.Contracts;
    using CargoSystem.Web.ViewModels.Home;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class HomeServices : BaseServices, IHomeServices
    {
        public HomeServices(ICargoSystemData data)
            : base(data)
        {
        }

        public IList<CarrierViewModel> GetLastRegisteredCarriersViewModel(int numberOfCarriers)
        {
            var usersViewModel = this.Data
             .Users
             .All()
             .Where(u => u.isCarrier)
             .OrderByDescending(u => u.CreatedOn)
             .Take(numberOfCarriers)
             .Project()
             .To<CarrierViewModel>()
             .ToList();

            return usersViewModel;
        }

        public IList<SpeditorViewModel> GetLastRegisteredSpeditorsViewModel(int numberOfSpeditors)
        {
            var speditorViewModel = this.Data
             .Users
             .All()
             .Where(u => !u.isCarrier)
             .OrderByDescending(u => u.CreatedOn)
             .Take(numberOfSpeditors)
             .Project()
             .To<SpeditorViewModel>()
             .ToList();

            return speditorViewModel;
        }

        public IList<RouteViewModel> GetLastRoutes(int numberOfRoutes)
        {
            var routesViewModel = this.Data
                .Routes
            .All()
            .Where(r=>r.TransportStartDate>DateTime.Now)
            .OrderByDescending(u => u.CreatedOn)
            .Take(numberOfRoutes)
            .Project()
            .To<RouteViewModel>()
            .ToList();

            return routesViewModel;
        }
    }
}