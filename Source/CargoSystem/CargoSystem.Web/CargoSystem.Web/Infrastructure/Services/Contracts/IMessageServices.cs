namespace CargoSystem.Web.Infrastructure.Services.Contracts
{
    using CargoSystem.Data.Models;
    using System.Collections.Generic;
    using System.Linq;

    public interface IMessageServices
    {
        IQueryable<User> GetUserEmailsContainingInTheName(string searchedName);
    }
}