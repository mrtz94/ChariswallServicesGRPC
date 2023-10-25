using ChariswallNewDomain.Models;
using ChariswallNewServices.UnitOfWork;
using ChariswallServices.Protos;
using ChariswallServices.Services.IDataSourceServices;

namespace ChariswallServices.Services.DataSourceServices
{
    public class ExchangeAccountSService : IExchangeAccountSService
    {
        IUnitOfWork _unitOfWork;
        public ExchangeAccountSService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public accountList GetAccounts()
        {
            var accs = _unitOfWork.ExchangeBankAccounts.GetAll();
            var accList = new accountList();
            foreach (var acc in accs)
                accList.Accounts.Add(new account { Id = acc.Id, AccNum = acc.ShabaNumber, Bank = acc.Bank, Enable = acc.Enable ?? false });
            return accList;
        }
        public accountList GetActive()
        {
            var accs = _unitOfWork.ExchangeBankAccounts.GetAll().Where(w => w.Enable ?? false);
            var accList = new accountList();
            foreach (var acc in accs)
                accList.Accounts.Add(new account { Id = acc.Id, AccNum = acc.ShabaNumber, Bank = acc.Bank, Enable = acc.Enable ?? false });
            return accList;
        }
        public void AddAccount(account acc)
        {
            _unitOfWork.ExchangeBankAccounts.Add(new ExchangeBankAccount { Bank = acc.Bank, Enable = true, Default = false, ShabaNumber = acc.AccNum });
            _unitOfWork.Complete();
        }
        public void DisableAccount(int id)
        {
            var acc = _unitOfWork.ExchangeBankAccounts.GetById(id);
            acc.Enable = false;
            _unitOfWork.ExchangeBankAccounts.Edit(acc);
            _unitOfWork.Complete();
        }
        public void SetDefault(int id)
        {
            var acc = _unitOfWork.ExchangeBankAccounts.GetById(id);
            acc.Default = true;
            _unitOfWork.ExchangeBankAccounts.Edit(acc);
            _unitOfWork.Complete();
        }
    }
}
