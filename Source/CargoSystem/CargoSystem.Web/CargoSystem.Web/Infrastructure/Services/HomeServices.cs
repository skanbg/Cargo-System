namespace CargoSystem.Web.Infrastructure.Services
{
    using AutoMapper.QueryableExtensions;
    using CargoSystem.Data;
    using CargoSystem.Data.Models;
    using CargoSystem.Web.Infrastructure.Services.Base;
    using CargoSystem.Web.Infrastructure.Services.Contracts;
    using CargoSystem.Web.ViewModels.Home;
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

        public IList<UserViewModel> GetLastRegisteredSpeditorsViewModel(int numberOfSpeditors)
        {
            var usersViewModel = this.Data
             .Users
             .All()
             .Where(u => !u.isCarrier)
             .OrderByDescending(u => u.CreatedOn)
             .Take(numberOfSpeditors)
             .Project()
             .To<UserViewModel>()
             .ToList();

            return usersViewModel;
        }
    }
}