namespace CargoSystem.Web.Areas.Carrier.ViewModels.Offer
{
    using System.ComponentModel.DataAnnotations;
    using AutoMapper;
    using CargoSystem.Data.Models;
    using CargoSystem.Web.Infrastructure.Mapping;

    public class VehicleViewModel : IMapFrom<Vehicle>, IHaveCustomMappings
    {
        [ScaffoldColumn(false)]
        public string Id { get; set; }

        public TrailerSize Dimensions { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Vehicle, VehicleViewModel>()
            .ForMember(m => m.Id, u => u.MapFrom(t => t.Id))
            .ForMember(m => m.Dimensions, u => u.MapFrom(t => t.Dimensions))
            .ReverseMap();
        }
    }
}