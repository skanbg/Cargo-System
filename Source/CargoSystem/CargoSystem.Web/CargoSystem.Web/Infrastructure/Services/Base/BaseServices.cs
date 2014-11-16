namespace CargoSystem.Web.Infrastructure.Services.Base
{
    using CargoSystem.Data;

    public abstract class BaseServices
    {
        public BaseServices(ICargoSystemData data)
        {
            this.Data = data;
        }

        protected ICargoSystemData Data { get; private set; }
    }
}
