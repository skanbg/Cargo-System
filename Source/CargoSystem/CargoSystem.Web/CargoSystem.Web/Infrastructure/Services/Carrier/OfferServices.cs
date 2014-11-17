namespace CargoSystem.Web.Infrastructure.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper.QueryableExtensions;
    using CargoSystem.Data;
    using CargoSystem.Web.Infrastructure.Services.Base;
    using CargoSystem.Web.Infrastructure.Services.Contracts.Carrier;

    public class OfferServices : BaseServices, IOfferServices
    {
        public OfferServices(ICargoSystemData data)
            : base(data)
        {
        }
    }
}