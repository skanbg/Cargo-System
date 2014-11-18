namespace CargoSystem.Web.Areas.Administration.ViewModels.Feedbacks
{
    using System;
    using System.Collections.Generic;

    public class IndexViewModel
    {
        public ICollection<FeedbackViewModel> Feedbacks { get; set; }

        public int CurrentPage { get; set; }

        public int FeedbacksOnPage { get; set; }

        public int FeedbacksCount { get; set; }
    }
}