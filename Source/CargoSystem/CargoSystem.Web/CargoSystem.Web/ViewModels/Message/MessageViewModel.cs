namespace CargoSystem.Web.ViewModels.Message
{
    using AutoMapper;
    using CargoSystem.Data.Models;
    using CargoSystem.Web.Infrastructure.Mapping;
    using System.ComponentModel.DataAnnotations;

    public class MessageViewModel : IMapFrom<Message>, IHaveCustomMappings
    {
        [Required(ErrorMessage = "Receiver must be selected")]
        public string ReceiverId { get; set; }

        [Required(ErrorMessage = "Provide message title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Provide message text")]
        [DataType(DataType.MultilineText)]
        public string Body { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Message, MessageViewModel>()
            .ForMember(m => m.ReceiverId, u => u.MapFrom(t => t.Receiver.Id))
            .ForMember(m => m.Title, u => u.MapFrom(t => t.Title))
            .ForMember(m => m.Body, u => u.MapFrom(t => t.Body))
            .ReverseMap();
        }
    }
}