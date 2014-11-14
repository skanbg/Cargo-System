namespace CargoSystem.Web.ViewModels.Home
{
    using System.Collections.Generic;

    public class IndexViewModel
    {
        public IEnumerable<RouteViewModel> Routes { get; set; }
    }
}