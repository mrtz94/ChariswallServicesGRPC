using ChariswallNewDomain.Models;

namespace ChariswallNewRepositories.IRepository
{
    public interface INimaOfferStateRepository : IQueryRepository<NimaOfferState>, ICommandRepository<NimaOfferState>
    {
        int GetOfferState(string statetitle);
    }
}
