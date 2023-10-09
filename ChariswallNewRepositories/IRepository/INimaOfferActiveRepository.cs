using ChariswallNewDomain.Models;

namespace ChariswallNewRepositories.IRepository
{
    public interface INimaOfferActiveRepository : IQueryRepository<NimaOfferActive>, ICommandRepository<NimaOfferActive>
    {
    }
}
