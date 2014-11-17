namespace CargoSystem.Web.Infrastructure.Services.Contracts
{
    public interface INotificationServices
    {
        int GetIncomeMessagesCount(string userId);

        int GetDelayedDeliveriesCount(string userId);

        int GetStartedDeliveriesCount(string userId);

        int GetCanceledDeliveriesCount(string userId);
    }
}