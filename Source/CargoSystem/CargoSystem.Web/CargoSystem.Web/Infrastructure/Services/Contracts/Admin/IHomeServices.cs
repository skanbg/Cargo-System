namespace CargoSystem.Web.Infrastructure.Services.Contracts.Admin
{
    using CargoSystem.Web.Areas.Administration.ViewModels.Users;
    using System.Collections.Generic;

    public interface IHomeServices
    {
        IList<UserViewModel> GetUsers(int numberOfUsers);
    }
}
