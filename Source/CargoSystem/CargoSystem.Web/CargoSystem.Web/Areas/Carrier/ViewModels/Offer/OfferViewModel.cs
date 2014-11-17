namespace CargoSystem.Web.Areas.Carrier.ViewModels.Offer
{
    using System.ComponentModel.DataAnnotations;
    using AutoMapper;
    using CargoSystem.Data.Models;
    using CargoSystem.Web.Infrastructure.Mapping;

    public class OfferViewModel : IMapFrom<Offer>, IHaveCustomMappings
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        public SpeditorViewModel Speditor { get; set; }

        public decimal Price { get; set; }

        public PackageViewModel Package { get; set; }

        public RouteViewModel Route { get; set; }

        public OfferStatus OfferStatus { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Offer, OfferViewModel>()
            .ForMember(m => m.Id, u => u.MapFrom(t => t.Id))
            .ForMember(m => m.Speditor, u => u.MapFrom(t => t.Speditor))
            .ForMember(m => m.Price, u => u.MapFrom(t => t.Price))
            .ForMember(m => m.Package, u => u.MapFrom(t => t.Package))
            .ForMember(m => m.Route, u => u.MapFrom(t => t.Route))
            .ForMember(m => m.OfferStatus, u => u.MapFrom(t => t.OfferStatus))
            .ReverseMap();
        }
    }
}