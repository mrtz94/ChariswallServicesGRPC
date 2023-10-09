using ChariswallNewDomain.Models;

namespace ChariswallNewRepositories.IRepository
{
    public interface INimaRequestStateRepository : IQueryRepository<NimaRequestState>, ICommandRepository<NimaRequestState>
    {
        int GetRequestState(string rstitle);
    }
}
