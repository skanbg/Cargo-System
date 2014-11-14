using CargoSystem.Data.Models;
using CargoSystem.Web.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CargoSystem.Web.ViewModels
{
    public class IndexCarrierViewModel : IMapFrom<Carrier>
    {
        public string Email { get; set; }
    }
}