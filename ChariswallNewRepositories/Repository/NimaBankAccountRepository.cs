using ChariswallNewDomain.Context;
using ChariswallNewDomain.Models;
using ChariswallNewRepositories.IRepository;

namespace ChariswallNewRepositories.Repository
{
    public class NimaBankAccountRepository : ChariswallRepository<NimaBankAccount>, INimaBankAccountRepository
    {
        public NimaBankAccountRepository(ChariswallDemoDbContext context) : base(context)
        {
        }

        public int? GetBankAcc(string accNum, int bank, string owner, string shaba, int customer)
        {
            var bankaccId = _context.NimaBankAccounts.FirstOrDefault(f => f.AccountNumber == accNum && f.Bank == bank && f.OwnerName == owner && f.ShabaNumber == shaba && f.Customer == customer)?.Id;
            if (bankaccId == null)
            {
                var bankacc = new NimaBankAccount { AccountNumber = accNum, Bank = bank, OwnerName = owner, ShabaNumber = shaba, Customer = customer };
                _context.NimaBankAccounts.Add(bankacc);
                _context.SaveChanges();
                bankaccId = bankacc.Id;
            }
            return bankaccId;
        }
    }
}
