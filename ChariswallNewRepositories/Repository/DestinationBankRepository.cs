using ChariswallNewDomain.Context;
using ChariswallNewDomain.Models;
using ChariswallNewRepositories.IRepository;

namespace ChariswallNewRepositories.Repository
{
    public class DestinationBankRepository : ChariswallRepository<DestinationBank>, IDestinationBankRepository
    {
        public DestinationBankRepository(ChariswallDemoDbContext context) : base(context)
        {
        }

        public int GetBank(string bankname)
        {
            var bankId = _context.DestinationBanks.FirstOrDefault(f => f.Title == bankname)?.Id;
            if (bankId == null)
            {
                var bank = new DestinationBank { Title = bankname, Enable = true };
                _context.DestinationBanks.Add(bank);
                _context.SaveChanges();
                bankId = bank.Id;
            }
            return bankId ?? 0;
        }
    }
}
