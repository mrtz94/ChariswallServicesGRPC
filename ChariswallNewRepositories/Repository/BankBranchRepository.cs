using ChariswallNewDomain.Context;
using ChariswallNewDomain.Models;
using ChariswallNewRepositories.IRepository;

namespace ChariswallNewRepositories.Repository
{
    public class BankBranchRepository : ChariswallRepository<BankBranch>, IBankBranchRepository
    {
        public BankBranchRepository(ChariswallDemoDbContext context) : base(context)
        {
        }

        public int? GetBranch(string bb)
        {
            var bankBranchId = _context.BankBranches.FirstOrDefault(f => f.Title == bb)?.Id;
            if (bankBranchId == null)
            {
                var bankBranch = new BankBranch { Title = bb };
                _context.BankBranches.Add(bankBranch);
                _context.SaveChanges();
                bankBranchId = bankBranch.Id;
            }
            return bankBranchId;
        }
    }
}
