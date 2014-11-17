namespace CargoSystem.Web.Areas.Carrier.ViewModels.Offer
{
    using System.ComponentModel.DataAnnotations;
    using AutoMapper;
    using CargoSystem.Data.Models;
    using CargoSystem.Web.Infrastructure.Mapping;

    public class AddressViewModel : IMapFrom<Address>, IHaveCustomMappings
    {
        [ScaffoldColumn(false)]
        public string Id { get; set; }

        public string CountryName { get; set; }

        public string Town { get; set; }

        public string Street { get; set; }

        public string Apartment { get; set; }

        public string PostCode { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Address, AddressViewModel>()
            .ForMember(m => m.Id, u => u.MapFrom(t => t.Id))
            .ForMember(m => m.CountryName, u => u.MapFrom(t => t.Country.Name))
            .ForMember(m => m.Town, u => u.MapFrom(t => t.Town))
            .ForMember(m => m.Street, u => u.MapFrom(t => t.Street))
            .ForMember(m => m.Apartment, u => u.MapFrom(t => t.Apartment))
            .ForMember(m => m.PostCode, u => u.MapFrom(t => t.PostCode))
            .ReverseMap();
        }
    }
}
