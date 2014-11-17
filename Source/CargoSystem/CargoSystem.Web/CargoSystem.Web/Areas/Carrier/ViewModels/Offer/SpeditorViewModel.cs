namespace CargoSystem.Web.Areas.Carrier.ViewModels.Offer
{
    using System.ComponentModel.DataAnnotations;
    using AutoMapper;
    using CargoSystem.Data.Models;
    using CargoSystem.Web.Infrastructure.Mapping;

    public class SpeditorViewModel : IMapFrom<User>, IHaveCustomMappings
    {
        [ScaffoldColumn(false)]
        public string Id { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<User, SpeditorViewModel>()
            .ForMember(m => m.Id, u => u.MapFrom(t => t.Id))
            .ForMember(m => m.Email, u => u.MapFrom(t => t.Email))
            .ForMember(m => m.FirstName, u => u.MapFrom(t => t.FirstName))
            .ForMember(m => m.MiddleName, u => u.MapFrom(t => t.MiddleName))
            .ForMember(m => m.LastName, u => u.MapFrom(t => t.LastName))
            .ReverseMap();
        }
    }
}