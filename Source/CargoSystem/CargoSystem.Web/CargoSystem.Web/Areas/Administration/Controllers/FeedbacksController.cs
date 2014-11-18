namespace CargoSystem.Web.Areas.Administration.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Caching;
    using System.Web.Mvc;
    using AutoMapper.QueryableExtensions;
    using CargoSystem.Data;
    using CargoSystem.Web.Areas.Administration.ViewModels.Feedbacks;

    public class FeedbacksController : AdminController
    {
        private const int FeedbacksOnPage = 4;
        private const int FeedbackCacheInterval = 30; // in seconds

        public FeedbacksController(ICsData data):base(data)
        {
        }

        // GET: PageableFeedbackList
        public ActionResult Index(int? page = 0)
        {
            // this.Cache.Remove("time");
            if (this.HttpContext.Cache[page.ToString()] == null)
            {
                var feedbacks = this.Data.Feedbacks.All();
                var selectedFeedbacksQuery = feedbacks
                    .OrderBy(f => f.Id).AsQueryable();
                if (page != null && page > 0)
                {
                    selectedFeedbacksQuery = selectedFeedbacksQuery.Skip((page.GetValueOrDefault(0) - 1) * FeedbacksOnPage).AsQueryable();
                }

                selectedFeedbacksQuery = selectedFeedbacksQuery
                    .Take(FeedbacksOnPage);

                var selectedFeedbacks = selectedFeedbacksQuery
                    .Project().To<FeedbackViewModel>().ToList();
                var model = new IndexViewModel()
                {
                    CurrentPage = page ?? 1,
                    Feedbacks = selectedFeedbacks,
                    FeedbacksCount = feedbacks.Count(),
                    FeedbacksOnPage = FeedbacksOnPage
                };

                this.HttpContext.Cache.Insert(
                page.ToString(), // key
                model, // value
                null, // dependencies
                DateTime.Now.AddSeconds(FeedbackCacheInterval), // absolute exp.
                TimeSpan.Zero, // sliding exp.
                CacheItemPriority.Default, // priority
                this.OnCacheItemRemovedCallback); // callback delegate
            }

            var cachedModel = this.HttpContext.Cache[page.ToString()] as IndexViewModel;
            return this.View(cachedModel);
        }

        private void OnCacheItemRemovedCallback(string key, object value, CacheItemRemovedReason reason)
        {
        }
    }
}