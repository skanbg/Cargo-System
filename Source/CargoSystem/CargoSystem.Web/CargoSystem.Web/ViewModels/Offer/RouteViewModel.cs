namespace CargoSystem.Web.ViewModels.Offer
{
    using System;
    using AutoMapper;
    using CargoSystem.Data.Models;
    using CargoSystem.Web.Infrastructure.Mapping;

    public class RouteViewModel : IMapFrom<Route>, IHaveCustomMappings
    {
        public virtual Address StartPoint { get; set; }

        public virtual Address EndPoint { get; set; }

        public DateTime? TransportStartDate { get; set; }

        public DateTime? TransportEndDate { get; set; }

        public virtual CarrierViewModel Carrier { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Route, RouteViewModel>()
            .ForMember(m => m.StartPoint, u => u.MapFrom(t => t.StartPoint))
            .ForMember(m => m.EndPoint, u => u.MapFrom(t => t.EndPoint))
            .ForMember(m => m.TransportStartDate, u => u.MapFrom(t => t.TransportStartDate))
            .ForMember(m => m.TransportEndDate, u => u.MapFrom(t => t.TransportEndDate))
            .ForMember(m => m.Carrier, u => u.MapFrom(t => t.Carrier))
            .ReverseMap();
        }
    }
}