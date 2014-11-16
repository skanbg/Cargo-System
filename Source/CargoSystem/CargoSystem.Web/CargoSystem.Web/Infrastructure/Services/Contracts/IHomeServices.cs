namespace CargoSystem.Web.Infrastructure.Services.Contracts
{
    using System.Collections.Generic;
    using CargoSystem.Web.ViewModels.Home;

    public interface IHomeServices
    {
        IList<CarrierViewModel> GetLastRegisteredCarriersViewModel(int numberOfCarriers);

        IList<SpeditorViewModel> GetLastRegisteredSpeditorsViewModel(int numberOfSpeditors);

        IList<RouteViewModel> GetLastRoutes(int numberOfRoutes);
    }
}
