using CargoSystem.Data.Models;
using CargoSystem.Web.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CargoSystem.Data.Models;
using AutoMapper;
using CargoSystem.Web.Infrastructure.Helpers.Toastr;

namespace CargoSystem.Web.ViewModels.Notification
{
    public class NotificationMessageViewModel : IMapFrom<CargoSystem.Data.Models.Notification>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Message { get; set; }

        public NotificationType NotificationType { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<CargoSystem.Data.Models.Notification, NotificationMessageViewModel>()
            .ForMember(m => m.Id, u => u.MapFrom(t => t.Id))
            .ForMember(m => m.Title, u => u.MapFrom(t => t.Title))
            .ForMember(m => m.Message, u => u.MapFrom(t => t.Message))
            .ForMember(m => m.NotificationType, u => u.MapFrom(t => t.NotificationType))
            .ReverseMap();
        }
    }
}