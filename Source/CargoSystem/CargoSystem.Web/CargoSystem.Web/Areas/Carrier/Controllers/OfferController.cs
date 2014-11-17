namespace CargoSystem.Web.Areas.Carrier.Controllers
{
    using System.Globalization;
    using System.Web.Mvc;
    using System.Linq;
    using AutoMapper;
    using Kendo.Mvc.UI;
    using Kendo.Mvc.Extensions;
    using CargoSystem.Data;
    using CargoSystem.Web.Infrastructure.Services.Contracts.Carrier;
    using CargoSystem.Web.Areas.Carrier.ViewModels.Offer;
    using CargoSystem.Web.Areas.Carrier.Controllers.Base;
    using CargoSystem.Data.Models;

    public class OfferController : CarrierController
    {
        private IOfferServices offerServices;

        public OfferController(ICsData data, IOfferServices offerServices)
            : base(data)
        {
            this.offerServices = offerServices;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult ReadOffers([DataSourceRequest]DataSourceRequest request)
        {
            var offersDataSource = this.Data.Offers.All().Where(o => o.Carrier.Id == this.UserProfile.Id)
                .ToDataSourceResult(request, offer => Mapper.Map<OfferViewModel>(offer));

            return this.Json(offersDataSource);
        }

        [HttpPost]
        public ActionResult DestroyOffer([DataSourceRequest]DataSourceRequest request, OfferViewModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                var offer = this.Data.Offers.All().FirstOrDefault(o => o.Id == model.Id);
                if (offer != null)
                {
                    offer.OfferStatus = OfferStatus.Rejected;
                    this.Data.SaveChanges();
                }
            }

            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }

        [HttpPost]
        public ActionResult AcceptOffer([DataSourceRequest]DataSourceRequest request, OfferViewModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                var offer = this.Data.Offers.All().FirstOrDefault(o => o.Id == model.Id);
                if (offer != null)
                {
                    offer.OfferStatus = OfferStatus.Rejected;
                    this.Data.SaveChanges();
                }
            }

            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }
    }
}