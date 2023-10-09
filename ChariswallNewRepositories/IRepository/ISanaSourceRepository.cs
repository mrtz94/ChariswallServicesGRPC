using ChariswallNewDomain.Models;

namespace ChariswallNewRepositories.IRepository
{
    public interface ISanaSourceRepository : IQueryRepository<SanaSource>, ICommandRepository<SanaSource>
    {
        int GetSource(string sourceName);
    }
}
