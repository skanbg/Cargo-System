namespace CargoSystem.Web.ViewModels.Home
{
    using AutoMapper;
    using CargoSystem.Data.Models;
    using CargoSystem.Web.Infrastructure.Mapping;
    using System.Linq;

    public class SpeditorViewModel : IMapFrom<User>, IHaveCustomMappings
    {
        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int ClosedBargainsCount { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<User, SpeditorViewModel>()
            .ForMember(m => m.Email, u => u.MapFrom(t => t.Email))
            .ForMember(m => m.FirstName, u => u.MapFrom(t => t.FirstName))
            .ForMember(m => m.LastName, u => u.MapFrom(t => t.LastName))
            .ForMember(m => m.ClosedBargainsCount, u => u.MapFrom(t => t.Offers.Where(o => o.OfferStatus == OfferStatus.Finished).Count()))
            .ReverseMap();
        }
    }
}