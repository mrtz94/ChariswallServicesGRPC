using ChariswallNewDomain.Context;
using ChariswallNewDomain.Models;
using ChariswallNewRepositories.IRepository;

namespace ChariswallNewRepositories.Repository
{
    public class ExchangeBankAccountRepository : ChariswallRepository<ExchangeBankAccount>, IExchangeBankAccountRepository
    {
        public ExchangeBankAccountRepository(ChariswallDemoDbContext context) : base(context)
        {
        }

        public int GetAccount(string bank, string shaba)
        {
            var accId = _context.ExchangeBankAccounts.FirstOrDefault(f => f.Bank.Trim() == bank.Trim() && f.ShabaNumber.Trim() == shaba.Trim())?.Id;
            if (accId == null)
            {
                var acc = new ExchangeBankAccount { Bank = bank.Trim(), ShabaNumber = shaba.Trim() };
                _context.ExchangeBankAccounts.Add(acc);
                _context.SaveChanges();
                accId = acc.Id;
            }
            return accId ?? 0;
        }
    }
}
