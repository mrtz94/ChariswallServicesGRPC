using ChariswallNewDomain.Models;

namespace ChariswallNewRepositories.IRepository
{
    public interface INimaBankRepository : IQueryRepository<NimaBank>, ICommandRepository<NimaBank>
    {
        int GetBank(string bankname);
    }
}
