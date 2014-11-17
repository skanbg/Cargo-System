namespace CargoSystem.Web.Areas.Carrier.ViewModels.Offer
{
    using System.ComponentModel.DataAnnotations;
    using AutoMapper;
    using CargoSystem.Data.Models;
    using CargoSystem.Web.Infrastructure.Mapping;

    public class PackageViewModel : IMapFrom<Package>, IHaveCustomMappings
    {
        [ScaffoldColumn(false)]
        public string Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        public AddressViewModel SenderAddress { get; set; }

        public AddressViewModel ReceiverAddress { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Package, PackageViewModel>()
            .ForMember(m => m.Id, u => u.MapFrom(t => t.Id))
            .ForMember(m => m.Name, u => u.MapFrom(t => t.Name))
            .ForMember(m => m.Description, u => u.MapFrom(t => t.Description))
            .ForMember(m => m.SenderAddress, u => u.MapFrom(t => t.SenderAddress))
            .ForMember(m => m.ReceiverAddress, u => u.MapFrom(t => t.ReceiverAddress))
            .ReverseMap();
        }
    }
}