namespace CargoSystem.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using Microsoft.AspNet.Identity;
    using CargoSystem.Data;
    using CargoSystem.Web.InputModels.Feedback;
    using CargoSystem.Data.Models;
    using System.Web.Security;
    using CargoSystem.Common;
    using System.Collections.Generic;

    public class FeedbackController : BaseController
    {
        public FeedbackController(ICsData data)
            : base(data)
        {
        }

        [HttpGet]
        public ActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FeedbackInputModel input)
        {
            if (ModelState.IsValid)
            {
                var userId = this.User.Identity.GetUserId();

                var feedback = new Feedback
                {
                    Title = input.Title,
                    Content = input.Content,
                    AuthorId = userId
                };

                this.Data.Feedbacks.Add(feedback);
                this.Data.Feedbacks.SaveChanges();

                this.TempData["message"] = "Feedback sent!";
                var admins = this.GetAllAdmins();
                var userName = userId == null ? "Anonymous user" : feedback.Author.FirstName;
                this.Notify(admins, "New feedback", userName + " added new feedback", NotificationType.Info);
                return this.RedirectToAction("Index", "Home", null);
            }

            return this.View(input);
        }

        private ICollection<string> GetAllAdmins()
        {
            var adminIds = this.Data.Users.All().Where(u => u.Email == "admin@admin.com")
                .Select(a => a.Id).ToList();

            return adminIds;
        }
    }
}