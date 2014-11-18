namespace CargoSystem.Web.ViewModels.Message
{
    using AutoMapper;
    using CargoSystem.Data.Models;
    using CargoSystem.Web.Infrastructure.Mapping;

    public class AutocompleteUserView : IMapFrom<User>, IHaveCustomMappings
    {
        public string ReceiverId { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<User, AutocompleteUserView>()
            .ForMember(m => m.ReceiverId, u => u.MapFrom(t => t.Id))
            .ForMember(m => m.Email, u => u.MapFrom(t => t.Email))
            .ForMember(m => m.FirstName, u => u.MapFrom(t => t.FirstName))
            .ForMember(m => m.MiddleName, u => u.MapFrom(t => t.MiddleName))
            .ForMember(m => m.LastName, u => u.MapFrom(t => t.LastName))
            .ReverseMap();
        }
    }
}