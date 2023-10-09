using ChariswallNewDomain.Models;

namespace ChariswallNewRepositories.IRepository
{
    public interface ISanaActionRepository : IQueryRepository<SanaAction>, ICommandRepository<SanaAction>
    {
        int GetAction(string actionName);
    }
}
