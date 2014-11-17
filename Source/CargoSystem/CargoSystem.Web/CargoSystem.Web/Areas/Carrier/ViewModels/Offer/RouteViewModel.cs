namespace CargoSystem.Web.Areas.Carrier.ViewModels.Offer
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using AutoMapper;
    using CargoSystem.Data.Models;
    using CargoSystem.Web.Infrastructure.Mapping;

    public class RouteViewModel : IMapFrom<Route>, IHaveCustomMappings
    {
        [ScaffoldColumn(false)]
        public string Id { get; set; }

        public virtual AddressViewModel StartPoint { get; set; }

        public virtual AddressViewModel EndPoint { get; set; }

        public virtual VehicleViewModel Vehicle { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Route, RouteViewModel>()
            .ForMember(m => m.StartPoint, u => u.MapFrom(t => t.StartPoint))
            .ForMember(m => m.EndPoint, u => u.MapFrom(t => t.EndPoint))
            .ForMember(m => m.Vehicle, u => u.MapFrom(t => t.Vehicle))
            .ReverseMap();
        }
    }
}