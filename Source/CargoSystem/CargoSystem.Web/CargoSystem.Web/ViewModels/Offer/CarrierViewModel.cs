namespace CargoSystem.Web.ViewModels.Offer
{
    using AutoMapper;
    using CargoSystem.Data.Models;
    using CargoSystem.Web.Infrastructure.Mapping;

    public class CarrierViewModel : IMapFrom<User>, IHaveCustomMappings
    {
        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int VehiclesCount { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<User, CarrierViewModel>()
            .ForMember(m => m.Email, u => u.MapFrom(t => t.Email))
            .ForMember(m => m.FirstName, u => u.MapFrom(t => t.FirstName))
            .ForMember(m => m.LastName, u => u.MapFrom(t => t.LastName))
            .ForMember(m => m.VehiclesCount, u => u.MapFrom(t => t.Vehicles.Count))
            .ReverseMap();
        }
    }
}