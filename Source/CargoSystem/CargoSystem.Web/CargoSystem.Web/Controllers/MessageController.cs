using CargoSystem.Data;
using CargoSystem.Web.Infrastructure.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;
using CargoSystem.Web.ViewModels.Message;
using CargoSystem.Data.Models;
using CargoSystem.Web.Infrastructure.Helpers.Toastr.ControllerExtensions;
using AutoMapper;

namespace CargoSystem.Web.Controllers
{
    [Authorize]
    public class MessageController : BaseController
    {
        private IMessageServices messageServices;

        public MessageController(ICsData data, IMessageServices messageServices)
            : base(data)
        {
            this.messageServices = messageServices;
        }

        public ActionResult All()
        {
            return View();
        }

        // GET: Message
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Message
        [HttpPost]
        public ActionResult Create(MessageViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                var receiver = this.Data.Users.All().FirstOrDefault(u => u.Id == model.ReceiverId);
                if (receiver != null)
                {
                    var message = Mapper.Map<Message>(model);
                    message.SenderId = this.UserProfile.Id;
                    this.Data.Messages.Add(message);
                    this.Data.Messages.SaveChanges();

                    this.Notify(message.Receiver.Id, "New message", "Message from " + message.Sender.FirstName, NotificationType.Info);
                    this.AddToastMessage("Message sent", "Message to " + message.Receiver.FirstName + "delivered", NotificationType.Info);
                }
            }

            return this.View(model);
        }

        public JsonResult GetUsersWithName(string text)
        {
            var users = this.messageServices.GetUserEmailsContainingInTheName(text)
                .Project().To<AutocompleteUserView>().ToList();
            return Json(users, JsonRequestBehavior.AllowGet);
        }
    }
}