using CargoSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoSystem.Web.Infrastructure.Services.Base
{
    public abstract class BaseServices
    {
        protected ICargoSystemData Data { get; private set; }

        public BaseServices(ICargoSystemData data)
        {
            this.Data = data;
        }
    }
}
