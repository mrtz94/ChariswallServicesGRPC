using ChariswallServices.Protos;

namespace ChariswallServices.Services.IDataSourceServices
{
    public interface IExchangeAccountSService
    {
        accountList GetAccounts();
        accountList GetActive();
        void AddAccount(account acc);
        void DisableAccount(int id);
        void SetDefault(int id);
    }
}
