namespace CargoSystem.Web.Infrastructure.Services.Admin
{
    using AutoMapper.QueryableExtensions;
    using CargoSystem.Data;
    using CargoSystem.Web.Areas.Administration.ViewModels.Users;
    using CargoSystem.Web.Infrastructure.Services.Base;
    using CargoSystem.Web.Infrastructure.Services.Contracts.Admin;
    using System.Collections.Generic;
    using System.Linq;

    public class HomeServices : BaseServices, IHomeServices
    {
        public HomeServices(ICargoSystemData data)
            : base(data)
        {
        }

        public IList<UserViewModel> GetUsers(int numberOfUsers)
        {
            var usersViewModel = this.Data
             .Users
             .All()
             .OrderByDescending(u => u.CreatedOn)
             .Take(numberOfUsers)
             .Project()
             .To<UserViewModel>()
             .ToList();

            return usersViewModel;
        }
    }
}