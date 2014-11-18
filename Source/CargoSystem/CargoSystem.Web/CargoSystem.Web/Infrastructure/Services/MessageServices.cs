namespace CargoSystem.Web.Infrastructure.Services
{
    using CargoSystem.Data;
    using CargoSystem.Data.Models;
    using CargoSystem.Web.Infrastructure.Services.Base;
    using CargoSystem.Web.Infrastructure.Services.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class MessageServices : BaseServices, IMessageServices
    {
        private const int MaxReturnedResults = 10;

        public MessageServices(ICargoSystemData data)
            : base(data)
        {
        }

        public IQueryable<User> GetUserEmailsContainingInTheName(string searchedName)
        {
            var emails = this.Data.Users.All().Where(u => u.FirstName.Contains(searchedName) || u.MiddleName.Contains(searchedName) || u.LastName.Contains(searchedName)).Take(MaxReturnedResults);
            return emails;
        }
    }
}