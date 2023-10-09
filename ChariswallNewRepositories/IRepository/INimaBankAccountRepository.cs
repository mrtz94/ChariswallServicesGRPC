using ChariswallNewDomain.Models;

namespace ChariswallNewRepositories.IRepository
{
    public interface INimaBankAccountRepository : IQueryRepository<NimaBankAccount>, ICommandRepository<NimaBankAccount>
    {
        int? GetBankAcc(string accNum, int bank, string owner, string shaba, int customer);
    }
}
