using ChariswallNewDomain.Context;
using ChariswallNewDomain.Models;
using ChariswallNewRepositories.IRepository;

namespace ChariswallNewRepositories.Repository
{
    public class NimaBankRepository : ChariswallRepository<NimaBank>, INimaBankRepository
    {
        public NimaBankRepository(ChariswallDemoDbContext context) : base(context)
        {
        }

        public int GetBank(string bankname)
        {
            var bankId = _context.NimaBanks.FirstOrDefault(f => f.Title == bankname)?.Id;
            if (bankId == null)
            {
                var bank = new NimaBank { Title = bankname };
                _context.NimaBanks.Add(bank);
                _context.SaveChanges();
                bankId = bank.Id;
            }
            return bankId ?? 0;
        }
    }
}
