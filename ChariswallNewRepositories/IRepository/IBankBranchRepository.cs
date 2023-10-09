using ChariswallNewDomain.Models;

namespace ChariswallNewRepositories.IRepository
{
    public interface IBankBranchRepository : IQueryRepository<BankBranch>, ICommandRepository<BankBranch>
    {
        int? GetBranch(string bb);
    }
}
