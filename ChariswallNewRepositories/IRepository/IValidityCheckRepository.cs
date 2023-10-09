using ChariswallNewDomain.Models;

namespace ChariswallNewRepositories.IRepository
{
    public interface IValidityCheckRepository : IQueryRepository<ValidityCheck>, ICommandRepository<ValidityCheck>
    {
        int GetVCheck(string vcheckname);
    }
}
