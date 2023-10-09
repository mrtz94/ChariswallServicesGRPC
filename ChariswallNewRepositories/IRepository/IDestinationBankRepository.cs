using ChariswallNewDomain.Models;

namespace ChariswallNewRepositories.IRepository
{
    public interface IDestinationBankRepository : IQueryRepository<DestinationBank>, ICommandRepository<DestinationBank>
    {
        int GetBank(string bankname);
    }
}
